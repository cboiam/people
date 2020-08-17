using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ValidPeople.Domain.Enumerations;
using ValidPeople.Web.Shared;

namespace ValidPeople.Web.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResourcesController : ControllerBase
    {
        private readonly IMapper mapper;

        public ResourcesController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        public Resource Get() =>
            new Resource
            {
                Hobbies = GetEnumerationResource<HobbyEnumeration>(),
                ParentRelations = GetEnumerationResource<RelationEnumeration>()
            };

        private IEnumerable<EnumerationViewModel> GetEnumerationResource<T>()
            where T : Enumeration
        {
            var values = Enumeration.GetAll<T>();
            return mapper.Map<IEnumerable<EnumerationViewModel>>(values);
        }
    }
}
