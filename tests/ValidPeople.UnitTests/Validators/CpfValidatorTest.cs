using FluentValidation.TestHelper;
using FluentValidation.Validators;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using ValidPeople.Application.Interfaces.Validators;
using ValidPeople.Application.Validators;
using ValidPeople.Web.Shared.People;
using Xunit;

namespace ValidPeople.UnitTests.Validators
{
    public class CpfValidatorTest
    {
        private readonly Mock<ICpfNumberValidator> cpfNumberValidator;
        private readonly CpfValidator validator;

        public CpfValidatorTest()
        {
            cpfNumberValidator = new Mock<ICpfNumberValidator>();

            validator = new CpfValidator(cpfNumberValidator.Object);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ValidateNumber_ShouldReturnValidationError_WhenEmpty(string number) =>
            validator.ShouldHaveValidationErrorFor(x => x.Number, number)
                .WithErrorMessage("Cpf should not be empty.");

        [Theory]
        [InlineData("12345678910")]
        [InlineData("1aa45678910")]
        [InlineData("1234567 910")]
        [InlineData("123.4567.910")]
        public void ValidateNumber_ShouldReturnValidationError_WhenWrongFormat(string number) =>
            validator.ShouldHaveValidationErrorFor(x => x.Number, number)
                .WithErrorMessage("Cpf format is invalid.");

        [Fact]
        public async Task Validate_ShouldReturnValidationError_WhenInvalidNumber()
        {
            var cpf = "123.456.789-10";

            cpfNumberValidator.Setup(x => x.Validate(cpf, It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            (await validator.ShouldHaveValidationErrorForAsync(x => x.Number, new CpfViewModel { Number = cpf }))
                .WithErrorMessage("Cpf is invalid.");
        }

        [Fact]
        public async Task ValidateNumber_ShouldBeValid()
        {
            var cpf = "123.456.789-10";

            cpfNumberValidator.Setup(x => x.Validate(cpf, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            await validator.ShouldNotHaveValidationErrorForAsync(x => x.Number, new CpfViewModel { Number = cpf });
        }

        [Fact]
        public void ValidateEmission_ShouldBeValid_WhenEmissionInPast() =>
            validator.ShouldNotHaveValidationErrorFor(x => x.Emission, DateTime.Now.AddDays(-1));

        [Fact]
        public void ValidateEmission_ShouldReturnValidationError_WhenEmissionInFuture() =>
            validator.ShouldHaveValidationErrorFor(x => x.Emission, DateTime.Now.AddDays(1))
                .WithErrorMessage("Cpf emission should be in the past.");

        [Fact]
        public void ValidateExpiration_ShouldBeValid_WhenEmissionInFuture() =>
            validator.ShouldNotHaveValidationErrorFor(x => x.Expiration, DateTime.Now.AddDays(1));

        [Fact]
        public void ValidateExpiration_ShouldReturnValidationError_WhenEmissionInPast() =>
            validator.ShouldHaveValidationErrorFor(x => x.Expiration, DateTime.Now.AddDays(-1))
                .WithErrorMessage("Cpf expiration should be in the future.");
    }
}
