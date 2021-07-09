using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SynetecAssessmentApi.Persistence;
using Serilog;
using Serilog.Events;
using System;
using SynetecAssessmentApi.Persistence.Concrete.EntityFramework.Contexts;

namespace SynetecAssessmentApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Verbose()
         .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Information)
                     .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
                     .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                     .MinimumLevel.Override("System", LogEventLevel.Information)
        .Enrich.FromLogContext()
        .WriteTo.File(
            "Logs/log-.txt",
            shared: true,
            flushToDiskInterval: TimeSpan.FromSeconds(5),
            rollingInterval: RollingInterval.Day)
        .CreateLogger();




            try
            {
                Log.Information("Host starting.");

                var webHost = BuildWebHost(args);


                using (var scope = webHost.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var context = services.GetRequiredService<AppDbContext>();

                    DbContextGenerator.Initialize(services);
                }


                webHost.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
     WebHost.CreateDefaultBuilder(args)
         .CaptureStartupErrors(true)
         .UseUrls("http://localhost:5003")
         .UseStartup<Startup>()
         .UseContentRoot(Directory.GetCurrentDirectory())
         .ConfigureLogging(options =>
         {
             options.ClearProviders();
         })         .UseSerilog()
         .Build();
    }
    
}
