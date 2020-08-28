using FluentValidation;
using System.Linq;
using ValidPeople.Domain.Enumerations;
using ValidPeople.Web.Shared;

namespace ValidPeople.Application.Validators
{
    public static class EnumerationValidatorExtension
    {
        public static IRuleBuilderOptions<T, EnumerationViewModel> IsInEnumeration<T, TEnumeration>(this IRuleBuilder<T, EnumerationViewModel> ruleBuilder, string enumerationErrorName)
            where TEnumeration : Enumeration
        {
            return ruleBuilder
                .Must(x => x != null && Enumeration.GetAll<TEnumeration>().Any(y => y.Id == x.Id))
                    .WithMessage(string.Format(ValidationMessages.InvalidEnumerationMessage, enumerationErrorName));
        }
    }
}
