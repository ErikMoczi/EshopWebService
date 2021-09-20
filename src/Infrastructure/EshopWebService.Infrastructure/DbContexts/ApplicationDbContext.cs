using EshopWebService.Domain.Entities;
using EshopWebService.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EshopWebService.Infrastructure.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}