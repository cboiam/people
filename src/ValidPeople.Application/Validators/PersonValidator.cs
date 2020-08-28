using FluentValidation;
using System;
using ValidPeople.Application.Interfaces.Validators;
using ValidPeople.Domain.Enumerations;
using ValidPeople.Web.Shared.People;

namespace ValidPeople.Application.Validators
{
    public class PersonValidator : AbstractValidator<PersonViewModel>
    {
        public PersonValidator(IValidator<NameViewModel> nameValidator,
            IValidator<ParentViewModel> parentValidator,
            IValidator<CpfViewModel> cpfValidator,
            IEducationalLevelRegressionValidator educationalLevelRegressionValidator)
        {
            RuleFor(x => x.Name)
                .Must(x => x.GetFormattedName().Length <= 100)
                    .WithMessage("Name is too long.")
                    .When(x => x.Name != null)
                .NotNull()
                    .WithMessage(string.Format(ValidationMessages.MandatoryFieldMessage, "Name"))
                .SetValidator(nameValidator);

            RuleFor(x => x.Birth)
                .LessThanOrEqualTo(DateTime.Now)
                    .WithMessage("You weren't born yet.");

            RuleFor(x => x.Email)
                .EmailAddress()
                    .WithMessage(string.Format(ValidationMessages.InvalidFormatMessage, "Email"))
                    .When(x => !string.IsNullOrWhiteSpace(x.Email));
            
            RuleFor(x => x.Email)
                .NotEmpty()
                    .WithMessage(string.Format(ValidationMessages.MandatoryFieldMessage, "Email"))
                    .When(x => x.Birth >= DateTime.Now.AddYears(-60));

            RuleFor(x => x.Revenue)
                .GreaterThanOrEqualTo(0)
                    .WithMessage("Revenue shouldn't be negative.");

            RuleFor(x => x.Hobby)
                .NotEqual(HobbyEnumeration.Sports.ToViewModel())
                    .WithMessage("I doubt it.")
                    .When(x => x.Profession != null && x.Profession.Equals("Developer", StringComparison.InvariantCultureIgnoreCase))
                .IsInEnumeration<PersonViewModel, HobbyEnumeration>("hobbies");

            RuleFor(x => x.Cpf)
                .NotNull()
                    .WithMessage(string.Format(ValidationMessages.MandatoryFieldMessage, "Cpf"))
                .SetValidator(cpfValidator);

            RuleFor(x => x.EducationalLevel)
                .IsInEnumeration<PersonViewModel, EducationalLevelEnumeration>("educational levels");

            When(x => x.Cloned, () =>
            {
                RuleFor(x => x.Parents)
                    .Empty()
                        .WithMessage("Clones don't have parents.");
            }).Otherwise(() =>
            {
                RuleFor(x => x.Parents)
                    .NotEmpty()
                        .WithMessage("You need a parent.")
                    .Must(x => x?.Count <= 2)
                        .WithMessage("Too much parents.");

                RuleForEach(x => x.Parents)
                    .SetValidator(parentValidator);
            });

            RuleSet("Update", () =>
            {
                RuleFor(x => x.Status)
                    .IsInEnumeration<PersonViewModel, StatusEnumeration>("status");

                RuleFor(x => x.EducationalLevel)
                    .MustAsync(educationalLevelRegressionValidator.Validate)
                        .WithMessage("Can't regress any level in your education.");
            });
        }
    }
}
