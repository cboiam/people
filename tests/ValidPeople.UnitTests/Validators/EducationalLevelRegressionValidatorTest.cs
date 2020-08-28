using FluentAssertions;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using ValidPeople.Application.Interfaces.UseCases;
using ValidPeople.Application.Responses.People;
using ValidPeople.Application.Validators;
using ValidPeople.Domain.Enumerations;
using ValidPeople.Web.Shared.People;
using Xunit;

namespace ValidPeople.UnitTests.Validators
{
    public class EducationalLevelRegressionValidatorTest
    {
        private readonly Mock<IGetPersonUseCase> getPersonUseCase;
        private readonly EducationalLevelRegressionValidator educationalLevelRegressionValidator;

        public EducationalLevelRegressionValidatorTest()
        {
            getPersonUseCase = new Mock<IGetPersonUseCase>();
            educationalLevelRegressionValidator = new EducationalLevelRegressionValidator(getPersonUseCase.Object);
        }

        [Fact]
        public async Task Validate_ShouldBeValid_WhenSameEducationalLevel()
        {
            var person = new PersonViewModel
            {
                Id = Guid.NewGuid(),
                EducationalLevel = EducationalLevelEnumeration.HigherComplete.ToViewModel()
            };

            var personResponse = new PersonResponse
            {
                Id = Guid.NewGuid(),
                EducationalLevel = EducationalLevelEnumeration.HigherComplete
            };

            getPersonUseCase.Setup(x => x.Execute(person.Id))
                .ReturnsAsync(personResponse);

            var result = await educationalLevelRegressionValidator.Validate(person, person.EducationalLevel, new CancellationToken());

            result.Should().BeTrue();
        }

        [Fact]
        public async Task Validate_ShouldBeValid_WhenHigherEducationalLevel()
        {
            var person = new PersonViewModel
            {
                Id = Guid.NewGuid(),
                EducationalLevel = EducationalLevelEnumeration.HigherComplete.ToViewModel()
            };

            var personResponse = new PersonResponse
            {
                Id = Guid.NewGuid(),
                EducationalLevel = EducationalLevelEnumeration.PrimaryComplete
            };

            getPersonUseCase.Setup(x => x.Execute(person.Id))
                .ReturnsAsync(personResponse);

            var result = await educationalLevelRegressionValidator.Validate(person, person.EducationalLevel, new CancellationToken());

            result.Should().BeTrue();
        }

        [Fact]
        public async Task Validate_ShouldBeInvalid_WhenLowerEducationalLevel()
        {
            var person = new PersonViewModel
            {
                Id = Guid.NewGuid(),
                EducationalLevel = EducationalLevelEnumeration.PrimaryComplete.ToViewModel()
            };

            var personResponse = new PersonResponse
            {
                Id = Guid.NewGuid(),
                EducationalLevel = EducationalLevelEnumeration.HigherComplete
            };

            getPersonUseCase.Setup(x => x.Execute(person.Id))
                .ReturnsAsync(personResponse);

            var result = await educationalLevelRegressionValidator.Validate(person, person.EducationalLevel, new CancellationToken());

            result.Should().BeFalse();
        }
    }
}
