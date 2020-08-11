using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
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
        private readonly PeopleController instance;

        public PeopleControllerTest()
        {
            getPeopleUseCase = new Mock<IGetPeopleUseCase>();
            instance = new PeopleController(getPeopleUseCase.Object);
        }

        [Fact]
        public async Task GetPeople_ReturnsPeople()
        {
            var people = PersonFaker.Get().Generate(3);

            getPeopleUseCase.Setup(x => x.Execute())
                .ReturnsAsync(people);

            var response = await instance.GetAll();

            response.Result.Should().BeOfType<OkObjectResult>()
                .Which.Value.Should().BeEquivalentTo(people);
        }
    }
}
