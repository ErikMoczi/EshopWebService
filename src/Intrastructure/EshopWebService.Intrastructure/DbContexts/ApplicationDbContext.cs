using EshopWebService.Domain.Entities;
using EshopWebService.Intrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EshopWebService.Intrastructure.DbContexts
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