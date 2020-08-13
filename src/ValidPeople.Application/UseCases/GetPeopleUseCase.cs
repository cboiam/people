using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValidPeople.Application.Interfaces.Repositories;
using ValidPeople.Application.Interfaces.UseCases;
using ValidPeople.Application.Responses.People;

namespace ValidPeople.Application.UseCases
{
    public class GetPeopleUseCase : IGetPeopleUseCase
    {
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;

        public GetPeopleUseCase(IPersonRepository personRepository, IMapper mapper)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<PersonListResponse>> Execute()
        {
            var result = await personRepository.GetAll();
            return mapper.Map<IEnumerable<PersonListResponse>>(result);
        }
    }
}
