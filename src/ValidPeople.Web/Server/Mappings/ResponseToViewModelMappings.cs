using AutoMapper;
using ValidPeople.Application.Responses.People;
using ValidPeople.Domain.Enumerations;
using ValidPeople.Web.Shared;
using ValidPeople.Web.Shared.People;

namespace ValidPeople.Web.Server.Mappings
{
    public class ResponseToViewModelMappings : Profile
    {
        public ResponseToViewModelMappings()
        {
            CreateMap<PersonListResponse, PersonListViewModel>();
            CreateMap<PersonResponse, PersonViewModel>();
            CreateMap<NameResponse, NameViewModel>();
            CreateMap<CpfResponse, CpfViewModel>();
            CreateMap<ParentResponse, ParentViewModel>();
            CreateMap<Enumeration, EnumerationViewModel>();
        }
    }
}
