using ValidPeople.Application.Mappings;
using ValidPeople.Infra.Mappings;
using ValidPeople.Web.Server.Mappings;

namespace ValidPeople.UnitTests.Mappings
{
    public static class MapperConfiguration
    {
        public static AutoMapper.IMapper instance = new AutoMapper.MapperConfiguration(config =>
        {
            config.AddProfile<EntityToResponseProfile>();
            config.AddProfile<ModelToEntityProfile>();
            config.AddProfile<ResponseToViewModelMappings>();
            config.AddProfile<ViewModelToRequestProfile>();
            config.AddProfile<RequestToEntityProfile>();
            config.AddProfile<EntityToModelProfile>();
        }).CreateMapper();
    }
}