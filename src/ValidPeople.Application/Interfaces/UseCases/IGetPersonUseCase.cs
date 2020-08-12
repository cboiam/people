using System;
using System.Threading.Tasks;
using ValidPeople.Domain.Entities;

namespace ValidPeople.Application.Interfaces.UseCases
{
    public interface IGetPersonUseCase
    {
        Task<Person> Execute(Guid id);
    }
}
