using FluentAssertions;
using Moq;
using System.Threading.Tasks;
using ValidPeople.Application.Interfaces.Repositories;
using ValidPeople.Application.UseCases;
using ValidPeople.UnitTests.Fakers.Entities;
using ValidPeople.UnitTests.Mappings;
using Xunit;

namespace ValidPeople.UnitTests.UseCases
{
    public class GetPeopleUseCaseTest
    {
        private readonly Mock<IPersonRepository> personRepository;
        private readonly GetPeopleUseCase instance;

        public GetPeopleUseCaseTest()
        {
            personRepository = new Mock<IPersonRepository>();
            instance = new GetPeopleUseCase(personRepository.Object, MapperConfiguration.instance);
        }

        [Fact]
        public async Task Execute_ReturnsPeople()
        {
            var people = PersonFaker.Get().Generate(3);

            personRepository.Setup(x => x.GetAll())
                .ReturnsAsync(people);

            var result = await instance.Execute();
                
            result.Should().BeEquivalentTo(people.MapToResponse());
        }
    }
}
