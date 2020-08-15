using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ValidPeople.Application.Interfaces.UseCases;
using AutoMapper;
using ValidPeople.Web.Shared.People;

namespace ValidPeople.Web.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IGetPeopleUseCase getPeopleUseCase;
        private readonly IGetPersonUseCase getPersonUseCase;
        private readonly IMapper mapper;

        public PeopleController(IGetPeopleUseCase getPeopleUseCase, IGetPersonUseCase getPersonUseCase, IMapper mapper)
        {
            this.getPeopleUseCase = getPeopleUseCase;
            this.getPersonUseCase = getPersonUseCase;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonListViewModel>>> GetAll()
        {
            var people = await getPeopleUseCase.Execute();
            var result = mapper.Map<IEnumerable<PersonListViewModel>>(people);
            
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonViewModel>> Get(Guid id)
        {
            var person = await getPersonUseCase.Execute(id);
            var result = mapper.Map<PersonViewModel>(person);
            
            return Ok(result);
        }
    }
}
