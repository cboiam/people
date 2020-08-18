using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using ValidPeople.Application.Interfaces.UseCases;
using ValidPeople.Application.Requests.People;
using ValidPeople.UnitTests.Fakers.Entities;
using ValidPeople.UnitTests.Mappings;
using ValidPeople.Web.Server.Controllers;
using Xunit;

namespace ValidPeople.UnitTests.Controllers
{
    public class PeopleControllerTest
    {
        private readonly Mock<IGetPeopleUseCase> getPeopleUseCase;
        private readonly Mock<IGetPersonUseCase> getPersonUseCase;
        private readonly Mock<IDeletePersonUseCase> deletePersonUseCase;
        private readonly Mock<IAddPersonUseCase> postPersonUseCase;
        private readonly Mock<IUpdatePersonUseCase> updatePersonUseCase;
        private readonly PeopleController instance;

        public PeopleControllerTest()
        {
            getPeopleUseCase = new Mock<IGetPeopleUseCase>();
            getPersonUseCase = new Mock<IGetPersonUseCase>();
            deletePersonUseCase = new Mock<IDeletePersonUseCase>();
            postPersonUseCase = new Mock<IAddPersonUseCase>();
            updatePersonUseCase = new Mock<IUpdatePersonUseCase>();
            instance = new PeopleController(getPeopleUseCase.Object, getPersonUseCase.Object, deletePersonUseCase.Object, postPersonUseCase.Object, updatePersonUseCase.Object, MapperConfiguration.instance);
        }

        [Fact]
        public async Task GetAll_ReturnsPeople()
        {
            var people = PersonFaker.Get().Generate(3);

            getPeopleUseCase.Setup(x => x.Execute())
                .ReturnsAsync(people.MapToResponse());

            var response = await instance.GetAll();

            response.Result.Should().BeOfType<OkObjectResult>()
                .Which.Value.Should().BeEquivalentTo(people.MapToViewModel());
        }

        [Fact]
        public async Task Get_ReturnsPerson()
        {
            var id = Guid.NewGuid();
            var person = PersonFaker.Get().Generate();

            getPersonUseCase.Setup(x => x.Execute(id))
                .ReturnsAsync(person.MapToResponse());

            var response = await instance.Get(id);

            response.Result.Should().BeOfType<OkObjectResult>()
                .Which.Value.Should().BeEquivalentTo(person.MapToViewModel());
        }

        [Fact]
        public async Task Get_ReturnsNotFound_WhenPersonIsNull()
        {
            var response = await instance.Get(Guid.NewGuid());
            response.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task Delete_ReturnsNoContent_WhenDeletionSucceed()
        {
            var id = Guid.NewGuid();
            deletePersonUseCase.Setup(x => x.Execute(id))
                .ReturnsAsync(true);

            var response = await instance.Delete(id);
            response.Should().BeOfType<NoContentResult>();
        }

        [Fact]
        public async Task Delete_ReturnsNotFound_WhenDeletionFailed()
        {
            var id = Guid.NewGuid();
            deletePersonUseCase.Setup(x => x.Execute(id))
                .ReturnsAsync(false);

            var response = await instance.Delete(id);
            response.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task Update_ReturnsId_WhenUpdatedSuccessfully()
        {
            var id = Guid.NewGuid();
            var person = PersonFaker.Get().Generate().MapToViewModel();
            updatePersonUseCase.Setup(x => x.Execute(It.IsAny<PersonUpdateRequest>()))
                .ReturnsAsync(true);

            var response = await instance.Update(id, person);

            response.Result.Should().BeOfType<OkObjectResult>()
                .Which.Value.Should().Be(id);
        }

        [Fact]
        public async Task Update_ReturnsNotFound_WhenUpdateFailed()
        {
            var id = Guid.NewGuid();
            var person = PersonFaker.Get().Generate().MapToViewModel();
            updatePersonUseCase.Setup(x => x.Execute(It.IsAny<PersonUpdateRequest>()))
                .ReturnsAsync(false);

            var response = await instance.Update(id, person);

            response.Result.Should().BeOfType<NotFoundResult>();
        }
    }
}
