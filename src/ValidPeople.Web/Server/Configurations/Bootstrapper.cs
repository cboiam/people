using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ValidPeople.Application.Interfaces.Repositories;
using ValidPeople.Application.Interfaces.UseCases;
using ValidPeople.Application.Interfaces.Validators;
using ValidPeople.Application.UseCases;
using ValidPeople.Application.Validators;
using ValidPeople.Infra.FirebaseConfigurations;
using ValidPeople.Infra.Interfaces;
using ValidPeople.Infra.Repositories;
using ValidPeople.Web.Shared.People;

namespace ValidPeople.Web.Server.Configurations
{
    public static class Bootstrapper
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            return services.RegisterUseCases()
                .RegisterValidators()
                .RegisterRepositories();
        }

        public static IServiceCollection RegisterUseCases(this IServiceCollection services)
        {
            return services.AddScoped<IGetPeopleUseCase, GetPeopleUseCase>()
                .AddScoped<IGetPersonUseCase, GetPersonUseCase>()
                .AddScoped<IDeletePersonUseCase, DeletePersonUseCase>()
                .AddScoped<IAddPersonUseCase, AddPersonUseCase>()
                .AddScoped<IUpdatePersonUseCase, UpdatePersonUseCase>();
        }

        public static IServiceCollection RegisterValidators(this IServiceCollection services)
        {
            return services.AddScoped<IValidator<PersonViewModel>, PersonValidator>()
                .AddScoped<IValidator<NameViewModel>, NameValidator>()
                .AddScoped<IValidator<ParentViewModel>, ParentValidator>()
                .AddScoped<IValidator<CpfViewModel>, CpfValidator>()
                .AddScoped<ICpfNumberValidator, CpfNumberValidator>()
                .AddScoped<IEducationalLevelRegressionValidator, EducationalLevelRegressionValidator>();
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IFirebaseConnection, FirebaseConnection>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            
            return services;
        }
    }
}
