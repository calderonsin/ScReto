using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using SC.AdministradorLogs.Configuration;
using Serilog;

namespace SC.ProyectoAPIV3Core2.AppServices
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                 .UseIISIntegration()
                 .UseSerilog((context, configuration) => configuration.UseDefaultSettings(context))                 
                 .UseStartup<Startup>();

   
    }
}