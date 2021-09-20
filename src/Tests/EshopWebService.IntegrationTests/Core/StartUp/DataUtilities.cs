using System.Collections.Generic;
using EshopWebService.Domain.Entities;
using EshopWebService.Intrastructure.DbContexts;

namespace EshopWebService.IntegrationTests.Core.StartUp
{
    public static class DataUtilities
    {
        public static List<Product> InitializeDbForTests(ApplicationDbContext db)
        {
            var products = GetSeedingProducts();
            db.Products.AddRange(products);
            db.SaveChanges();

            return products;
        }

        public static List<Product> ReinitializeDbForTests(ApplicationDbContext db)
        {
            db.Products.RemoveRange(db.Products);
            return InitializeDbForTests(db);
        }

        public static List<Product> GetSeedingProducts()
        {
            return new List<Product>
            {
                new() { Id = 1, Name = "Product1", ImgUri = "/media/1/file.png", Price = 10.2m, Description = "HelloWorld1" },
                new() { Id = 2, Name = "Product2", ImgUri = "/media/2/file.png", Price = 10.3m, Description = "HelloWorld2" },
                new() { Id = 3, Name = "Product3", ImgUri = "/media/3/file.png", Price = 10.4m, Description = "HelloWorld3" },
                new() { Id = 4, Name = "Product4", ImgUri = "/media/4/file.png", Price = 10.5m, Description = "HelloWorld4" }
            };
        }
    }
}