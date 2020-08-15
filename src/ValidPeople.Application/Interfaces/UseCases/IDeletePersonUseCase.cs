using System;
using System.Threading.Tasks;

namespace ValidPeople.Application.Interfaces.UseCases
{
    public interface IDeletePersonUseCase
    {
        public Task<bool> Execute(Guid id);
    }
}
