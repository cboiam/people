using ValidPeople.Application.Mappings;
using ValidPeople.Infra.Mappings;

namespace ValidPeople.UnitTests.Mappings
{
    public static class MapperConfiguration
    {
        public static AutoMapper.IMapper instance = new AutoMapper.MapperConfiguration(config =>
        {
            config.AddProfile<EntityToResponseProfile>();
            config.AddProfile<ModelToEntityProfile>();
        }).CreateMapper();
    }
}
