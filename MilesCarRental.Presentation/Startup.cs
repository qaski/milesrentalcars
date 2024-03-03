using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MilesCarRental.Application.CarIdActualLocation.Services;
using MilesCarRental.Application.Localidades.Queries;
using MilesCarRental.Application.Localidades.Services;
using MilesCarRental.Domain.Repositories;
using MilesCarRental.Infrastructure.Repositories;
using MilesCarRental.WebApi.Controllers;

namespace MilesCarRental.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configuración de la conexión a SQL Server
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            // Registrar clases en la inyección de dependencias
            services.AddScoped<ILocalidadRepository, LocalidadRepository>(provider => new LocalidadRepository(connectionString));
            services.AddTransient<IGetLocalidadesQuery, GetLocalidadesQuery>();
            services.AddScoped<LocalidadService>();
            services.AddTransient<ICarIdActualLocationService, CarIdActualLocationService>();
            services.AddTransient<ICarIdActualLocationRepository>(provider => new CarIdActualLocationRepository(connectionString));

            // Add Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Name", Version = "v1" });
            });

            services.AddControllers(); // Add MVC Controllers

            // Other service configurations
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Production error handler
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Name V1");
                c.RoutePrefix = string.Empty; // Set Swagger UI at app root
            });

            app.UseHttpsRedirection(); // Enable HTTPS redirection

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Map MVC Controllers
            });
        }
    }
}
