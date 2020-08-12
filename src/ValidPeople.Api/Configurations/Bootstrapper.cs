using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ValidPeople.Application.Interfaces.Repositories;
using ValidPeople.Application.Interfaces.UseCases;
using ValidPeople.Application.UseCases;
using ValidPeople.Infra.FirebaseConfigurations;
using ValidPeople.Infra.Interfaces;
using ValidPeople.Infra.Repositories;

namespace ValidPeople.Api.Configurations
{
    public static class Bootstrapper
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            return services.RegisterUseCases()
                .RegisterRepositories(configuration);
        }

        public static IServiceCollection RegisterUseCases(this IServiceCollection services)
        {
            return services.AddScoped<IGetPeopleUseCase, GetPeopleUseCase>()
                .AddScoped<IGetPersonUseCase, GetPersonUseCase>();
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FirebaseConnectionOptions>(configuration.GetSection("FirebaseConnectionOptions"));

            services.AddSingleton<IFirebaseConnection, FirebaseConnection>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            
            return services;
        }
    }
}
