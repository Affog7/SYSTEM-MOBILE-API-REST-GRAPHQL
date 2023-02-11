using System.Net;
using MONAPI;

public class ProgramApi
{
    public static void Main(string[] args)
    {
        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
