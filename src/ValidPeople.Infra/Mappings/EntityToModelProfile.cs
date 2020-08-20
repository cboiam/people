using AutoMapper;
using Google.Cloud.Firestore;
using System;
using ValidPeople.Domain.Entities;

namespace ValidPeople.Infra.Mappings
{
    public class EntityToModelProfile : Profile
    {
        public EntityToModelProfile()
        {
            CreateMap<Person, Models.Person>()
                .ForMember(dest => dest.Hobby, opt => opt.MapFrom(src => src.Hobby.Id))
                .ForMember(dest => dest.EducationalLevel, opt => opt.MapFrom(src => src.EducationalLevel.Id))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Id));
            CreateMap<Name, Models.Name>();
            CreateMap<Parent, Models.Parent>()
                .ForMember(dest => dest.Relation, opt => opt.MapFrom(src => src.Relation.Id));
            CreateMap<Cpf, Models.Cpf>();

            CreateMap<DateTime, Timestamp>()
                .ConvertUsing(src => Timestamp.FromDateTime(src.ToUniversalTime()));
        }
    }
}
