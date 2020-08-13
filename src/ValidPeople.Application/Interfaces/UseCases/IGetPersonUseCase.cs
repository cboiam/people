using System;
using System.Threading.Tasks;
using ValidPeople.Application.Responses.People;

namespace ValidPeople.Application.Interfaces.UseCases
{
    public interface IGetPersonUseCase
    {
        Task<PersonResponse> Execute(Guid id);
    }
}
