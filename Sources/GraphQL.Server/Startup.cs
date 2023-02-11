namespace DemoGraphQL.Server
{
    using DemoGraphQL.Server.Contracts;
    using DemoGraphQL.Server.Entities.Context;
    using DemoGraphQL.Server.GraphQL.GraphQLSchema;
    using DemoGraphQL.Server.Repository;
    using EF;
    using global::GraphQL.Server;
    using global::Repository;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Server.Kestrel.Core;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using MONAPI.Mapper;
    using Services;
    using Services.Abstracts;
    using Services.UnitOfWork;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("DefaultPolicy");

            app.UseAuthorization();

            app.UseGraphQL<AppSchema>();
            app.UseGraphQLPlayground();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("DefaultPolicy", builder =>
                {
                    builder.AllowAnyHeader()
                       .WithMethods("GET", "POST")
                       .WithOrigins("https://localhost:44369");
                });
            });

            services.AddHttpContextAccessor();

          

            services.AddDbContext<MyDbContext>(options =>
              options.UseSqlite(Configuration.GetConnectionString("sqlConString")));

            services.AddScoped<MyDbContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

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

 
             services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IStockRepository, StockRepository>();

            services.AddScoped<AppSchema>();

            services.AddGraphQL()
               .AddSystemTextJson()
               .AddGraphTypes(typeof(AppSchema), ServiceLifetime.Scoped)
               .AddDataLoader();

            services.AddControllers()
               .AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }
    }
}