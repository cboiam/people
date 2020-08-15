using System;
using System.Threading.Tasks;
using ValidPeople.Application.Interfaces.Repositories;
using ValidPeople.Application.Interfaces.UseCases;

namespace ValidPeople.Application.UseCases
{
    public class DeletePersonUseCase : IDeletePersonUseCase
    {
        private readonly IPersonRepository personRepository;

        public DeletePersonUseCase(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public async Task<bool> Execute(Guid id) => await personRepository.Delete(id);
    }
}
