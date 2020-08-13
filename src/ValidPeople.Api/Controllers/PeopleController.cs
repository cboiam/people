using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValidPeople.Application.Interfaces.UseCases;
using ValidPeople.Application.Responses.People;

namespace ValidPeople.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IGetPeopleUseCase getPeopleUseCase;
        private readonly IGetPersonUseCase getPersonUseCase;

        public PeopleController(IGetPeopleUseCase getPeopleUseCase, IGetPersonUseCase getPersonUseCase)
        {
            this.getPeopleUseCase = getPeopleUseCase;
            this.getPersonUseCase = getPersonUseCase;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonListResponse>>> GetAll()
        {
            var result = await getPeopleUseCase.Execute();            
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PersonResponse>>> Get(Guid id)
        {
            var result = await getPersonUseCase.Execute(id);
            return Ok(result);
        }
    }
}
