using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using ValidPeople.Application.Interfaces.Repositories;
using ValidPeople.Application.UseCases;
using Xunit;

namespace ValidPeople.UnitTests.UseCases
{
    public class DeletePersonUseCaseTest
    {
        private readonly Mock<IPersonRepository> personRepository;
        private readonly DeletePersonUseCase instance;

        public DeletePersonUseCaseTest()
        {
            personRepository = new Mock<IPersonRepository>();
            instance = new DeletePersonUseCase(personRepository.Object);
        }

        [Fact]
        public async Task Execure_ReturnsTrue_WhenDeletionSucceed()
        {
            var id = Guid.NewGuid();
            personRepository.Setup(x => x.Delete(id))
                .ReturnsAsync(true);

            var result = await instance.Execute(id);

            result.Should().BeTrue();
        }

        [Fact]
        public async Task Execure_ReturnsFalse_WhenDeletionFails()
        {
            var id = Guid.NewGuid();
            personRepository.Setup(x => x.Delete(id))
                .ReturnsAsync(false);

            var result = await instance.Execute(id);

            result.Should().BeFalse();
        }
    }
}
