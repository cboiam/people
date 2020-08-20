using System.Collections.Generic;
using AutoMapper;
using ValidPeople.Application.Requests.People;
using ValidPeople.Domain.Entities;
using ValidPeople.Domain.Enumerations;

namespace ValidPeople.Application.Mappings
{
    public class RequestToEntityProfile : Profile
    {
        public RequestToEntityProfile()
        {
            CreateMap<PersonAddRequest, Person>().ConvertUsing((src, dest, ctx) => new Person(
                ctx.Mapper.Map<Name>(src.Name),
                src.Email,
                src.Birth,
                ctx.Mapper.Map<IEnumerable<Parent>>(src.Parents),
                ctx.Mapper.Map<Cpf>(src.Cpf),
                src.Hobby,
                src.Revenue,
                src.Profession,
                src.EducationalLevel,
                StatusEnumeration.Active,
                src.Cloned
            ));

            CreateMap<PersonUpdateRequest, Person>().ConvertUsing((src, dest, ctx) => new Person(
                src.Id,
                ctx.Mapper.Map<Name>(src.Name),
                src.Email,
                src.Birth,
                ctx.Mapper.Map<IEnumerable<Parent>>(src.Parents),
                ctx.Mapper.Map<Cpf>(src.Cpf),
                src.Hobby,
                src.Revenue,
                src.Profession,
                src.EducationalLevel,
                src.Status,
                src.Cloned
            ));

            CreateMap<NameRequest, Name>().ConvertUsing((src) => new Name(
                src.FirstName,
                src.LastName
            ));
            
            CreateMap<CpfRequest, Cpf>().ConstructUsing((src) => new Cpf(
                src.Number,
                src.Expiration,
                src.Emission
            ));
            
            CreateMap<ParentRequest, Parent>().ConvertUsing((src, dest, ctx) => new Parent(
                ctx.Mapper.Map<Name>(src.Name),
                src.Relation
            ));
        }
    }
}