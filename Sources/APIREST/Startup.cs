using System.Net;
using System.Text;
using AutoMapper;
using DTOs;
using EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Microsoft.VisualBasic;
using Models;
using MONAPI.Mapper;
using MONAPI.Swagger;
using Repository;
using Services;
using Services.Abstracts;
using Services.UnitOfWork;
using Swashbuckle.AspNetCore.SwaggerGen;
 
 
namespace MONAPI
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
            // Ajout de la base de données
            services.AddDbContext<MyDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            // Ajout des contrôleurs
            services.AddControllers();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Mapping
            var config = new MyMapper().ProductProfile();
            var mapper = config.CreateMapper();
            var config1 = new MyMapper().StockProfile();
            var mapper1 = config.CreateMapper();
            services.AddSingleton(mapper);
            services.AddSingleton(mapper1);



            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IStockService, StockService>();
            // Ajout de la compatibilité avec les versions

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IStockRepository, StockRepository>();


            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
            });
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenOptions>();

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddSingleton<ILoggerFactory, LoggerFactory>();
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
            services.AddLogging((builder) => builder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace));



        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

        
                app.UseSwaggerUI(options =>
                {
                    var provider = app.ApplicationServices.GetService<IApiVersionDescriptionProvider>();
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"My API {description.ApiVersion}");
                    }
                });

                   
            }

            // Utilisation de la redirection HTTPS
            app.UseHttpsRedirection();

            // Utilisation du routage
            app.UseRouting();

            // Utilisation des points de terminaison pour les contrôleurs
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }





        

    }
}
