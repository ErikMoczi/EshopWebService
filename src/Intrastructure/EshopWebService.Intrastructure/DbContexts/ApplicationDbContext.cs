using EshopWebService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EshopWebService.Intrastructure.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}