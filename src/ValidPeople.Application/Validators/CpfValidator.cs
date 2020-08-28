using FluentValidation;
using System;
using ValidPeople.Application.Interfaces.Validators;
using ValidPeople.Web.Shared.People;

namespace ValidPeople.Application.Validators
{
    public class CpfValidator : AbstractValidator<CpfViewModel>
    {
        public CpfValidator(ICpfNumberValidator cpfNumberValidator)
        {
            RuleFor(x => x.Number)
                .NotEmpty()
                    .WithMessage(string.Format(ValidationMessages.MandatoryFieldMessage, "Cpf"))
                .Matches("^\\d{3}.\\d{3}.\\d{3}\\-\\d{2}$")
                    .WithMessage(string.Format(ValidationMessages.InvalidFormatMessage, "Cpf"))
                .MustAsync(cpfNumberValidator.Validate)
                    .WithMessage("Cpf is invalid.");

            RuleFor(x => x.Emission)
                .LessThanOrEqualTo(DateTime.Now)
                    .WithMessage("Cpf emission should be in the past.");

            RuleFor(x => x.Expiration)
                .GreaterThan(DateTime.Now)
                    .WithMessage("Cpf expiration should be in the future.");
        }
    }
}
