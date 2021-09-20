using EshopWebService.Application.Interfaces.Repositories;
using EshopWebService.Infrastructure.DbContexts;
using EshopWebService.Infrastructure.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;

namespace EshopWebService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddPersistenceContexts();
            services.AddRepositories();
        }

        private static void AddPersistenceContexts(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<ProductRepository>();
            services.AddTransient<IProductRepository>(s => new ProductCachedRepository(s.GetRequiredService<ProductRepository>(), s.GetRequiredService<IDistributedCache>()));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}