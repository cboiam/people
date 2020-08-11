using System.Collections.Generic;
using System.Threading.Tasks;
using ValidPeople.Domain.Entities;

namespace ValidPeople.Application.Interfaces.UseCases
{
    public interface IGetPeopleUseCase
    {
        Task<IEnumerable<Person>> Execute();
    }
}
