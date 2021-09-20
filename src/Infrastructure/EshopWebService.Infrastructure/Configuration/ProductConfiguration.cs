using System.Collections.Generic;
using EshopWebService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EshopWebService.Infrastructure.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        private const int CreateTotalProducts = 100;

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.ImgUri).IsRequired();


            var products = new List<Product>();
            for (var i = 1; i <= CreateTotalProducts; i++)
            {
                products.Add(new Product
                {
                    Id = i,
                    Name = $"Product-{i}",
                    ImgUri = $"/media/{i}/file{i}.png",
                    Description = $"HelloWorld-{i}",
                    Price = i * 2.3m
                });
            }

            builder.HasData(products);
        }
    }
}