
using APIQL.Queries;
using APIQL.Schemas;
using APIQL.Types;
using EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Repository;
using Services;
using Services.Abstracts;
using Services.UnitOfWork;
using Newtonsoft.Json;
using GraphQL;
using MONAPI.Mapper;
using GraphQL.SystemTextJson;
using APIQL.Mutations;

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
 
 
            services
        .AddGraphQLServer()
        .AddDefaultTransactionScopeHandler() // create transaction scopes for mutation requests to wrap these in a transaction that we can control
        .AddQueryType<ProductQuery>()
        .AddMutationType<ProductMutation>()
        .AddMutationConventions(applyToAllMutations: true);

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

            services.AddScoped<ProductSchema>();

           

            services.Configure<KestrelServerOptions>(options => {
                options.AllowSynchronousIO = true;
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
              
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseGraphQL("/graphql");

            app.UseGraphQLPlayground(options : new GraphQL.Server.Ui.Playground.PlaygroundOptions());
            app.UseEndpoints( e => e.MapDefaultControllerRoute() );
        }

    }
}
