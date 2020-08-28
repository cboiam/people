using System.Threading;
using System.Threading.Tasks;
using ValidPeople.Web.Shared;
using ValidPeople.Web.Shared.People;

namespace ValidPeople.Application.Interfaces.Validators
{
    public interface IEducationalLevelRegressionValidator
    {
        Task<bool> Validate(PersonViewModel person, EnumerationViewModel educationalLevel, CancellationToken cancellationToken);
    }
}