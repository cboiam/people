using System.Collections.Generic;
using System.Threading.Tasks;
using ValidPeople.Application.Interfaces.Repositories;
using ValidPeople.Application.Interfaces.UseCases;
using ValidPeople.Domain.Entities;

namespace ValidPeople.Application.UseCases
{
    public class GetPeopleUseCase : IGetPeopleUseCase
    {
        private readonly IPersonRepository personRepository;

        public GetPeopleUseCase(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public async Task<IEnumerable<Person>> Execute()
        {
            return await personRepository.GetAll();
        }
    }
}
