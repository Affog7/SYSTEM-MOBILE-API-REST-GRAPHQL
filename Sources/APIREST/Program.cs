using System.Net;
using MONAPI;

public class ProgramApi
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                webBuilder.UseStartup<Startup>();
            });
}
