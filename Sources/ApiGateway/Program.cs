using System.Net;
using ApiGateway;
using Common.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace OcelotApiGw
{
    public class Program
    {
        public static void Main(string[] args)
        {
          
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
                  .ConfigureAppConfiguration((hostingContext, config) =>
                  {
                      config.AddJsonFile($"ocelot.json", false, true);
                  })
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                     webBuilder.UseStartup<Startup>();
                 });
    }
}