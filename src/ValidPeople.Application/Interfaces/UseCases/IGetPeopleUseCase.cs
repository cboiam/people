using System.Collections.Generic;
using System.Threading.Tasks;
using ValidPeople.Application.Responses.People;

namespace ValidPeople.Application.Interfaces.UseCases
{
    public interface IGetPeopleUseCase
    {
        Task<IEnumerable<PersonListResponse>> Execute();
    }
}
