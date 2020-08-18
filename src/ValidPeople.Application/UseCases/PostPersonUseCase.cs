using System;
using System.Threading.Tasks;
using AutoMapper;
using ValidPeople.Application.Interfaces.Repositories;
using ValidPeople.Application.Interfaces.UseCases;
using ValidPeople.Application.Requests.People;
using ValidPeople.Domain.Entities;

namespace ValidPeople.Application.UseCases
{
    public class PostPersonUseCase : IPostPersonUseCase
    {
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;

        public PostPersonUseCase(IPersonRepository personRepository, IMapper mapper)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
        }

        public async Task<Guid?> Execute(PersonRequest person)
        {
            if(person == null)
            {
                return null;
            }

            var entity = mapper.Map<Person>(person);
            await personRepository.Post(entity);
        
            return entity.Id;
        }
    }
}