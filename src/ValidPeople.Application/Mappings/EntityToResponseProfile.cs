using AutoMapper;
using ValidPeople.Application.Responses.People;
using ValidPeople.Domain.Entities;

namespace ValidPeople.Application.Mappings
{
    public class EntityToResponseProfile : Profile
    {
        public EntityToResponseProfile()
        {
            CreateMap<Person, PersonListResponse>()
                .ForMember(src => src.Cpf, opt => opt.MapFrom(dest => dest.Cpf.Number));

            CreateMap<Person, PersonResponse>();
            CreateMap<Name, NameResponse>();
            CreateMap<Cpf, CpfResponse>();
            CreateMap<Parent, ParentResponse>();
        }
    }
}
