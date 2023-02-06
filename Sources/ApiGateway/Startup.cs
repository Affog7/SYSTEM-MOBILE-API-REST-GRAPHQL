using System;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;

namespace ApiGateway;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddOcelot(Configuration);
        
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseOcelot().Wait();
    }
}
