using AutoMapper;
using System.Threading.Tasks;
using ValidPeople.Application.Interfaces.Repositories;
using ValidPeople.Application.Interfaces.UseCases;
using ValidPeople.Application.Requests.People;
using ValidPeople.Domain.Entities;

namespace ValidPeople.Application.UseCases
{
    public class UpdatePersonUseCase : IUpdatePersonUseCase
    {
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;

        public UpdatePersonUseCase(IPersonRepository personRepository, IMapper mapper)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
        }

        public async Task<bool> Execute(PersonUpdateRequest person)
        {
            var entity = mapper.Map<Person>(person);
            return await personRepository.Update(entity);
        }
    }
}
