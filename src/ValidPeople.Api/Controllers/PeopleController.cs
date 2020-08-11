using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValidPeople.Application.Interfaces.UseCases;
using ValidPeople.Domain.Entities;

namespace ValidPeople.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IGetPeopleUseCase getPeopleUseCase;

        public PeopleController(IGetPeopleUseCase getPeopleUseCase)
        {
            this.getPeopleUseCase = getPeopleUseCase;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetAll()
        {
            var result = await getPeopleUseCase.Execute();
            
            return Ok(result);
        }
    }
}
