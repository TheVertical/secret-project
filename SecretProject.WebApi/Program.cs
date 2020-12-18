using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SecretProject.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        //return Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //    webBuilder.UseKestrel()
        //    .UseContentRoot(Directory.GetCurrentDirectory())
        //    .ConfigureAppConfiguration((hostingContext, config) =>
        //    {
        //        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        config.AddEnvironmentVariables("Development");
        //        if (args != null)
        //            config.AddCommandLine(args);
        //    })
        //    .ConfigureLogging((hostingContext, logging) =>
        //    {
        //        logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
        //        logging.AddConsole();
        //        logging.AddDebug();
        //    })
        //    .UseIISIntegration()
        //    .UseStartup<Startup>();
        //});
    }
}
