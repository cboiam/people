using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ValidPeople.Web.Server.Mappings;
using ValidPeople.Application.Mappings;
using ValidPeople.Infra.Mappings;
using AutoMapper;
using ValidPeople.Web.Server.Configurations;

namespace ValidPeople.Web.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterDependencies(Configuration);

            services.AddAutoMapper(typeof(ModelToEntityProfile),
                typeof(EntityToResponseProfile),
                typeof(ResponseToViewModelMappings),
                typeof(ViewModelToRequestProfile),
                typeof(RequestToEntityProfile),
                typeof(EntityToModelProfile));

            services.AddSwaggerGen();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                // app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSwagger(options =>
            {
                options.RouteTemplate = "api/docs/{documentname}/swagger.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/api/docs/v1/swagger.json", "People Api");
                c.RoutePrefix = "api/docs";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
