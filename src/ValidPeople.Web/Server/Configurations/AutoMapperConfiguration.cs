using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ValidPeople.Application.Mappings;
using ValidPeople.Infra.Mappings;
using ValidPeople.Web.Server.Mappings;

namespace ValidPeople.Web.Server.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
        {
            return services.AddAutoMapper(typeof(ModelToEntityProfile),
                typeof(EntityToResponseProfile),
                typeof(ResponseToViewModelMappings),
                typeof(ViewModelToRequestProfile),
                typeof(RequestToEntityProfile),
                typeof(EntityToModelProfile));
        }
    }
}
