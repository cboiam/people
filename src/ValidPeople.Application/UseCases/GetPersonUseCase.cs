using System;
using System.Threading.Tasks;
using ValidPeople.Application.Interfaces.Repositories;
using ValidPeople.Application.Interfaces.UseCases;
using ValidPeople.Domain.Entities;

namespace ValidPeople.Application.UseCases
{
    public class GetPersonUseCase : IGetPersonUseCase
    {
        private readonly IPersonRepository personRepository;

        public GetPersonUseCase(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public async Task<Person> Execute(Guid id)
        {
            return await personRepository.Get(id);
        }
    }
}
