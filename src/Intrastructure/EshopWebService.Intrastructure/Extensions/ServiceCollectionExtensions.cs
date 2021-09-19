using EshopWebService.Application.Interfaces.Repositories;
using EshopWebService.Intrastructure.DbContexts;
using EshopWebService.Intrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EshopWebService.Intrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPersistenceContexts(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}