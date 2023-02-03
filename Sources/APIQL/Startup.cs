
using APIQL.Mutations;
using APIQL.Queries;
using EF;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
 using Repository;
using Services;
using Services.Abstracts;
using Services.UnitOfWork;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace APIQL
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

          



            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IStockService, StockService>();
            // Ajout de la compatibilité avec les versions

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IStockRepository, StockRepository>();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
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
