using System;
using System.Threading.Tasks;
using AutoMapper;
using ValidPeople.Application.Interfaces.Repositories;
using ValidPeople.Application.Interfaces.UseCases;
using ValidPeople.Application.Requests.People;
using ValidPeople.Domain.Entities;

namespace ValidPeople.Application.UseCases
{
    public class AddPersonUseCase : IAddPersonUseCase
    {
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;

        public AddPersonUseCase(IPersonRepository personRepository, IMapper mapper)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
        }

        public async Task<Guid> Execute(PersonAddRequest person)
        {
            var entity = mapper.Map<Person>(person);
            await personRepository.Add(entity);
        
            return entity.Id;
        }
    }
}