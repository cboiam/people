using AutoMapper;
using System;
using System.Collections.Generic;
using ValidPeople.Domain.Entities;
using ValidPeople.Domain.Enumerations;

namespace ValidPeople.Infra.Mappings
{
    public class EntityToModelProfile : Profile
    {
        public EntityToModelProfile()
        {
            CreateMap<Person, Models.Person>()
                .ForMember(dest => dest.Hobby, opt => opt.MapFrom(src => src.Hobby.Id));
            CreateMap<Name, Models.Name>();
            CreateMap<Parent, Models.Parent>()
                .ForMember(dest => dest.Relation, opt => opt.MapFrom(src => src.Relation.Id));
            CreateMap<Cpf, Models.Cpf>();
        }
    }
}
