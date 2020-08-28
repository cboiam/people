using FluentValidation;
using ValidPeople.Domain.Enumerations;
using ValidPeople.Web.Shared.People;

namespace ValidPeople.Application.Validators
{
    public class ParentValidator : AbstractValidator<ParentViewModel>
    {
        public ParentValidator(IValidator<NameViewModel> nameValidator)
        {
            RuleFor(x => x.Name)
                .Must(x => x.GetFormattedName().Length <= 100)
                    .WithMessage("Name is too long.")
                    .When(x => x.Name != null)
                .NotNull()
                    .WithMessage(string.Format(ValidationMessages.MandatoryFieldMessage, "Parent name"))
                .SetValidator(nameValidator);

            RuleFor(x => x.Relation)
                .IsInEnumeration<ParentViewModel, RelationEnumeration>("relations");
        }
    }
}
