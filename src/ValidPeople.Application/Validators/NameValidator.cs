using FluentValidation;
using ValidPeople.Web.Shared.People;

namespace ValidPeople.Application.Validators
{
    public class NameValidator : AbstractValidator<NameViewModel>
    {
        public NameValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                    .WithMessage(string.Format(ValidationMessages.MandatoryFieldMessage, "First name"));

            RuleFor(x => x.LastName)
                .NotEmpty()
                    .WithMessage(string.Format(ValidationMessages.MandatoryFieldMessage, "Last name"));
        }
    }
}
