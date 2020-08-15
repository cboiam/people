using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ValidPeople.Application.Interfaces.UseCases;
using AutoMapper;
using ValidPeople.Web.Shared.People;
using Microsoft.AspNetCore.Http;

namespace ValidPeople.Web.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IGetPeopleUseCase getPeopleUseCase;
        private readonly IGetPersonUseCase getPersonUseCase;
        private readonly IDeletePersonUseCase deletePersonUseCase;
        private readonly IMapper mapper;

        public PeopleController(IGetPeopleUseCase getPeopleUseCase, 
            IGetPersonUseCase getPersonUseCase, 
            IDeletePersonUseCase deletePersonUseCase,
            IMapper mapper)
        {
            this.getPeopleUseCase = getPeopleUseCase;
            this.getPersonUseCase = getPersonUseCase;
            this.deletePersonUseCase = deletePersonUseCase;
            this.mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PersonListViewModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PersonListViewModel>>> GetAll()
        {
            var people = await getPeopleUseCase.Execute();
            var result = mapper.Map<IEnumerable<PersonListViewModel>>(people);
            
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PersonViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonViewModel>> Get(Guid id)
        {
            var person = await getPersonUseCase.Execute(id);
            var result = mapper.Map<PersonViewModel>(person);
            
            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<StatusCodeResult> Delete(Guid id)
        {
            if(await deletePersonUseCase.Execute(id))
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
