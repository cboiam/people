using FluentAssertions;
using Moq;
using System.Threading.Tasks;
using ValidPeople.Application.Interfaces.Repositories;
using ValidPeople.Application.UseCases;
using ValidPeople.Domain.Entities;
using ValidPeople.UnitTests.Fakers.Entities;
using ValidPeople.UnitTests.Mappings;
using Xunit;

namespace ValidPeople.UnitTests.UseCases
{
    public class UpdatePersonUseCaseTest
    {
        private readonly Mock<IPersonRepository> personRepository;
        private readonly UpdatePersonUseCase instance;

        public UpdatePersonUseCaseTest()
        {
            personRepository = new Mock<IPersonRepository>();
            instance = new UpdatePersonUseCase(personRepository.Object, MapperConfiguration.instance);
        }

        [Fact]
        public async Task Execute_ReturnsTrue_WhenSuccess()
        {
            var person = PersonFaker.Get().Generate().MapToUpdateRequest();
            personRepository.Setup(x => x.Update(It.IsAny<Person>()))
                .ReturnsAsync(true);

            var result = await instance.Execute(person);
            
            result.Should().BeTrue();
        }

        [Fact]
        public async Task Execute_ReturnsFalse_WhenPersonDoNotExist()
        {
            var person = PersonFaker.Get().Generate().MapToUpdateRequest();
            personRepository.Setup(x => x.Update(It.IsAny<Person>()))
                .ReturnsAsync(false);

            var result = await instance.Execute(person);

            result.Should().BeFalse();
        }
    }
}
