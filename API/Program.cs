using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
           var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope(); 

            // the using keyword means after finishing the Main method, 
            // the scope will be disposed by the framework

            var services = scope.ServiceProvider; 
            
            try {
                var context = services.GetRequiredService<DataContext>();
                // population context var 
                await context.Database.MigrateAsync(); 
                await Seed.SeedData(context); 

            } catch (Exception ex) {
                var logger = services.GetRequiredService<ILogger<Program>>(); 
                logger.LogError(ex, "An error ocurred during migration");
            }

            await host.RunAsync(); 
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
