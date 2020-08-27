using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ValidPeople.Application.Interfaces.UseCases;
using AutoMapper;
using ValidPeople.Web.Shared.People;
using Microsoft.AspNetCore.Http;
using ValidPeople.Application.Requests.People;

namespace ValidPeople.Web.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IGetPeopleUseCase getPeopleUseCase;
        private readonly IGetPersonUseCase getPersonUseCase;
        private readonly IDeletePersonUseCase deletePersonUseCase;
        private readonly IAddPersonUseCase addPersonUseCase;
        private readonly IUpdatePersonUseCase updatePersonUseCase;
        private readonly IMapper mapper;

        public PeopleController(IGetPeopleUseCase getPeopleUseCase,
            IGetPersonUseCase getPersonUseCase,
            IDeletePersonUseCase deletePersonUseCase,
            IAddPersonUseCase addPersonUseCase,
            IUpdatePersonUseCase updatePersonUseCase,
            IMapper mapper)
        {
            this.getPeopleUseCase = getPeopleUseCase;
            this.getPersonUseCase = getPersonUseCase;
            this.deletePersonUseCase = deletePersonUseCase;
            this.addPersonUseCase = addPersonUseCase;
            this.updatePersonUseCase = updatePersonUseCase;
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

            if (result == null)
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
            if (await deletePersonUseCase.Execute(id))
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> Post(PersonViewModel person)
        {
            var result = await addPersonUseCase.Execute(mapper.Map<PersonAddRequest>(person));
            return Created($"/api/people/{result}", result);
        }


        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Guid>> Update(Guid id, PersonViewModel person)
        {
            person.Id = id;
            var result = await updatePersonUseCase.Execute(mapper.Map<PersonUpdateRequest>(person));

            if (!result)
            {
                return NotFound();
            }

            return Ok(person.Id);
        }
    }
}