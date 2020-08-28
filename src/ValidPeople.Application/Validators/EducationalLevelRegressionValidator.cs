using System.Threading;
using System.Threading.Tasks;
using ValidPeople.Application.Interfaces.UseCases;
using ValidPeople.Application.Interfaces.Validators;
using ValidPeople.Web.Shared;
using ValidPeople.Web.Shared.People;

namespace ValidPeople.Application.Validators
{
    public class EducationalLevelRegressionValidator : IEducationalLevelRegressionValidator
    {
        private readonly IGetPersonUseCase getPersonUseCase;

        public EducationalLevelRegressionValidator(IGetPersonUseCase getPersonUseCase)
        {
            this.getPersonUseCase = getPersonUseCase;
        }

        public async Task<bool> Validate(PersonViewModel person, EnumerationViewModel educationalLevel, CancellationToken cancellationToken)
        {
            var existingPerson = await getPersonUseCase.Execute(person.Id);
            return educationalLevel.Id >= existingPerson.EducationalLevel.Id;
        }
    }
}
