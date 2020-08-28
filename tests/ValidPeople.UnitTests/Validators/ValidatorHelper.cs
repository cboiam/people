using FluentValidation;
using FluentValidation.Results;
using Moq;

namespace ValidPeople.UnitTests.Validators
{
    internal static class ValidatorHelper
    {
        public static IValidator<T> GetMock<T>()
        {
            var validator = new Mock<IValidator<T>>();

            validator.Setup(x => x.Validate(It.IsAny<ValidationContext<T>>()))
                .Returns(new ValidationResult());

            return validator.Object;
        }
    }
}
