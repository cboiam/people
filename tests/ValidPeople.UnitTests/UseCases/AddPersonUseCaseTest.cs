using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using ValidPeople.Application.Interfaces.Repositories;
using ValidPeople.Application.UseCases;
using ValidPeople.UnitTests.Fakers.Entities;
using Xunit;
using ValidPeople.Domain.Entities;
using ValidPeople.Application.Requests.People;
using ValidPeople.UnitTests.Mappings;
using System;

namespace ValidPeople.UnitTests.UseCases
{
    public class AddPersonUseCaseTest
    {
        private readonly Mock<IPersonRepository> personRepository;
        private readonly AddPersonUseCase instance;

        public AddPersonUseCaseTest()
        {
            personRepository = new Mock<IPersonRepository>();
            instance = new AddPersonUseCase(personRepository.Object, MapperConfiguration.instance);
        }

        [Fact]
        public async Task Execute_InsertPerson()
        {
            var person = PersonFaker.Get().Generate().MapToAddRequest();
            
            var result = await instance.Execute(person);

            result.Should().NotBe(Guid.Empty);
        }
    }
}