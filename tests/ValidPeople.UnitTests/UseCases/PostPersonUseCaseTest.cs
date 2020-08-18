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
    public class PostPersonUseCaseTest
    {
        private readonly Mock<IPersonRepository> personRepository;
        private readonly PostPersonUseCase instance;

        public PostPersonUseCaseTest()
        {
            personRepository = new Mock<IPersonRepository>();
            instance = new PostPersonUseCase(personRepository.Object, MapperConfiguration.instance);
        }

        [Fact]
        public async Task Execute_InsertPerson()
        {
            var person = PersonFaker.Get().Generate().MapToRequest();
            
            var result = await instance.Execute(person);

            result.Should().NotBe(Guid.Empty);
        }

        [Fact]
        public async Task Execute_InsertPersonFail()
        {
            var person = null as Person;
            var entity = null as PersonRequest;

            personRepository.Setup(x => x.Post(person));
            var result = await instance.Execute(entity);

            result.Should().Be(null);
        }
    }
}