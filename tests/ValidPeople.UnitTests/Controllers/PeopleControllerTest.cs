using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using ValidPeople.Api.Controllers;
using ValidPeople.Application.Interfaces.UseCases;
using ValidPeople.UnitTests.Fakers.Entities;
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
            instance = new PeopleController(getPeopleUseCase.Object, getPersonUseCase.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsPeople()
        {
            var people = PersonFaker.Get().Generate(3);

            getPeopleUseCase.Setup(x => x.Execute())
                .ReturnsAsync(people);

            var response = await instance.GetAll();

            response.Result.Should().BeOfType<OkObjectResult>()
                .Which.Value.Should().BeEquivalentTo(people);
        }

        [Fact]
        public async Task Get_ReturnsPerson()
        {
            var id = Guid.NewGuid();
            var person = PersonFaker.Get().Generate();

            getPersonUseCase.Setup(x => x.Execute(id))
                .ReturnsAsync(person);

            var response = await instance.Get(id);

            response.Result.Should().BeOfType<OkObjectResult>()
                .Which.Value.Should().BeEquivalentTo(person);
        }
    }
}
