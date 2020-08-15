using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using ValidPeople.Application.Interfaces.UseCases;
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
        private readonly PeopleController instance;

        public PeopleControllerTest()
        {
            getPeopleUseCase = new Mock<IGetPeopleUseCase>();
            getPersonUseCase = new Mock<IGetPersonUseCase>();
            instance = new PeopleController(getPeopleUseCase.Object, getPersonUseCase.Object, MapperConfiguration.instance);
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
    }
}
