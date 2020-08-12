using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using ValidPeople.Application.Interfaces.Repositories;
using ValidPeople.Application.UseCases;
using ValidPeople.UnitTests.Fakers.Entities;
using Xunit;

namespace ValidPeople.UnitTests.UseCases
{
    public class GetPersonUseCaseTest
    {
        private readonly Mock<IPersonRepository> personRepository;
        private readonly GetPersonUseCase instance;

        public GetPersonUseCaseTest()
        {
            personRepository = new Mock<IPersonRepository>();
            instance = new GetPersonUseCase(personRepository.Object);
        }

        [Fact]
        public async Task Execute_ReturnsPeople()
        {
            var id = Guid.NewGuid();
            var person = PersonFaker.Get().Generate();

            personRepository.Setup(x => x.Get(id))
                .ReturnsAsync(person);

            var result = await instance.Execute(id);
                
            result.Should().BeEquivalentTo(person);
        }
    }
}
