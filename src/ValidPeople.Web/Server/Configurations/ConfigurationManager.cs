using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ValidPeople.Application.Options;
using ValidPeople.Infra.FirebaseConfigurations;

namespace ValidPeople.Web.Server.Configurations
{
    public static class ConfigurationManager
    {
        public static IServiceCollection BindConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            return services.Configure<IntegrationOptions>(configuration.GetSection("Integrations"))
                .Configure<FirebaseConnectionOptions>(configuration.GetSection("FirebaseConnectionOptions"));
        }
    }
}
