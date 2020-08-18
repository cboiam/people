using System.Threading.Tasks;
using ValidPeople.Application.Requests.People;

namespace ValidPeople.Application.Interfaces.UseCases
{
    public interface IUpdatePersonUseCase
    {
        Task<bool> Execute(PersonUpdateRequest person);
    }
}
