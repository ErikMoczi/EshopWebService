using System;
using EshopWebService.Intrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EshopWebService.Api.Extensions
{
    public static class HostExtensions
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using var serviceScope = host.Services.CreateScope();
            using var applicationDbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            var loggerFactory = serviceScope.ServiceProvider.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger("app");

            applicationDbContext.Database.EnsureCreated();

            try
            {
                if (!applicationDbContext.Database.IsInMemory())
                {
                    applicationDbContext.Database.Migrate();
                }

                logger.LogInformation("Finished Seeding Default Data");
                logger.LogInformation("Application Starting");
            }
            catch (Exception e)
            {
                logger.LogWarning(e, "An error occurred while seeding the DB");
            }

            return host;
        }
    }
}