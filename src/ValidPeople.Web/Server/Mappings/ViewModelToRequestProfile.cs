using AutoMapper;
using ValidPeople.Application.Requests.People;
using ValidPeople.Domain.Enumerations;
using ValidPeople.Web.Shared;
using ValidPeople.Web.Shared.People;

namespace ValidPeople.Web.Server.Mappings
{
    public class ViewModelToRequestProfile : Profile
    {
        public ViewModelToRequestProfile()
        {
            CreateMap<PersonViewModel, PersonAddRequest>();
            CreateMap<PersonViewModel, PersonUpdateRequest>();
            CreateMap<NameViewModel, NameRequest>();
            CreateMap<CpfViewModel, CpfRequest>();
            CreateMap<ParentViewModel, ParentRequest>();
            CreateMap<EnumerationViewModel, HobbyEnumeration>()
                .ConvertUsing((src) => Enumeration.FromValue<HobbyEnumeration>(src.Id));
            CreateMap<EnumerationViewModel, RelationEnumeration>()
                .ConvertUsing((src) => Enumeration.FromValue<RelationEnumeration>(src.Id));
            CreateMap<EnumerationViewModel, EducationalLevelEnumeration>()
                .ConvertUsing((src) => Enumeration.FromValue<EducationalLevelEnumeration>(src.Id));
            CreateMap<EnumerationViewModel, StatusEnumeration>()
                .ConvertUsing((src) => Enumeration.FromValue<StatusEnumeration>(src.Id));
        }
    }
}
