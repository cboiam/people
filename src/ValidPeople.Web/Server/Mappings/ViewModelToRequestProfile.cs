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

            CreateMap<HobbyEnumeration>();
            CreateMap<RelationEnumeration>();
            CreateMap<EducationalLevelEnumeration>();
            CreateMap<StatusEnumeration>();
        }

        private void CreateMap<T>() where T : Enumeration, new()
        {
            CreateMap<EnumerationViewModel, T>()
                .ConvertUsing((src) => Enumeration.FromValue<T>(src.Id));
        }
    }
}
