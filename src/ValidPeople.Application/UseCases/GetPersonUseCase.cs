using AutoMapper;
using System;
using System.Threading.Tasks;
using ValidPeople.Application.Interfaces.Repositories;
using ValidPeople.Application.Interfaces.UseCases;
using ValidPeople.Application.Responses.People;

namespace ValidPeople.Application.UseCases
{
    public class GetPersonUseCase : IGetPersonUseCase
    {
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;

        public GetPersonUseCase(IPersonRepository personRepository, IMapper mapper)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
        }

        public async Task<PersonResponse> Execute(Guid id)
        {
            var result = await personRepository.Get(id);
            return mapper.Map<PersonResponse>(result);
        }
    }
}
