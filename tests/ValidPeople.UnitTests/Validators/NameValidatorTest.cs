using FluentValidation.TestHelper;
using ValidPeople.Application.Validators;
using ValidPeople.Web.Shared.People;
using Xunit;

namespace ValidPeople.UnitTests.Validators
{
    public class NameValidatorTest
    {
        private readonly NameValidator validator;

        public NameValidatorTest()
        {
            validator = new NameValidator();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ValidateFirstName_ShouldReturnValidationError_WhenFirstNameIsEmpty(string firstName) =>
            validator.ShouldHaveValidationErrorFor(x => x.FirstName, firstName)
                .WithErrorMessage("First name should not be empty.");

        [Fact]
        public void ValidateFirstName_ShouldBeValid() =>
            validator.ShouldNotHaveValidationErrorFor(x => x.FirstName, "Firsname");

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ValidateLastName_ShouldReturnValidationError_WhenLastNameIsEmpty(string lastName) =>
            validator.ShouldHaveValidationErrorFor(x => x.LastName, lastName)
                .WithErrorMessage("Last name should not be empty.");

        [Fact]
        public void ValidateLastName_ShouldBeValid() =>
            validator.ShouldNotHaveValidationErrorFor(x => x.LastName, "Lastname");
    }
}
