using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using EshopWebService.Application.DTOs.Result;
using EshopWebService.Application.Extensions;
using EshopWebService.Application.Interfaces.Repositories;
using EshopWebService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EshopWebService.Intrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IRepository<Product> _repository;

        public ProductRepository(IRepository<Product> repository)
        {
            _repository = Guard.Against.Null(repository, nameof(repository));
        }

        public Task<Product> GetByIdAsync(int productId)
        {
            return _repository.AsQueryableAsync(queryable => queryable.Where(x => x.Id == productId).FirstOrDefaultAsync());
        }

        public Task<List<Product>> GetAsync()
        {
            return _repository.AsQueryableAsync(x => x.ToListAsync());
        }

        public Task<IPaginatedResultDto<Product>> GetAsync(int pageNumber, int pageSize)
        {
            return _repository.AsQueryableAsync(queryable => queryable.OrderBy(x => x.Id).ToPaginatedListAsync(pageNumber, pageSize));
        }

        public async Task<int> CreateAsync(Product product)
        {
            await _repository.CreateAsync(product);
            return product.Id;
        }

        public Task UpdateAsync(Product product)
        {
            return _repository.UpdateAsync(product);
        }

        public Task DeleteAsync(Product product)
        {
            return _repository.DeleteAsync(product);
        }
    }
}