using ValidPeople.Domain.Enumerations;
using ValidPeople.Web.Shared;

namespace ValidPeople.Application.Validators
{
    public static class EnumerationExtension
    {
        public static EnumerationViewModel ToViewModel(this Enumeration enumeration) =>
            new EnumerationViewModel
            {
                Id = enumeration.Id,
                Name = enumeration.Name
            };
    }
}
