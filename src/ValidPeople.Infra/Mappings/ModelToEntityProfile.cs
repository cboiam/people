using AutoMapper;
using System;
using System.Collections.Generic;
using ValidPeople.Domain.Entities;
using ValidPeople.Domain.Enumerations;

namespace ValidPeople.Infra.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<Models.Person, Person>()
                .ConvertUsing((src, dest, ctx) => new Person(Guid.Parse(src.Id),
                    ctx.Mapper.Map<Name>(src.Name),
                    src.Birth,
                    ctx.Mapper.Map<IEnumerable<Parent>>(src.Parents),
                    ctx.Mapper.Map<Cpf>(src.Cpf),
                    Enumeration.FromValue<HobbyEnumeration>(src.Hobby),
                    src.Revenue));

            CreateMap<Models.Name, Name>()
                .ConvertUsing(src => new Name(src.FirstName, src.LastName));

            CreateMap<Models.Parent, Parent>()
                .ConvertUsing((src, dest, ctx) => new Parent(ctx.Mapper.Map<Name>(src.Name), 
                    Enumeration.FromValue<RelationEnumeration>(src.Relation)));

            CreateMap<Models.Cpf, Cpf>()
                .ConvertUsing(src => new Cpf(src.Number, src.Expiration, src.Emission));
        }
    }
}
