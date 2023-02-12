namespace DemoGraphQL.Server
{
    using System.Net;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;
    using System.Security.Cryptography.X509Certificates;
    public class Program
    {

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                    webBuilder.UseStartup<Startup>();
                    
                });

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
    }
}