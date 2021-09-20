using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using EshopWebService.Application.DTOs.Result;
using EshopWebService.Application.Factories;
using EshopWebService.Application.Interfaces.Repositories;
using EshopWebService.Domain.Entities;
using EshopWebService.Infrastructure.Constatnts;
using Microsoft.Extensions.Caching.Distributed;
using DistributedCacheExtensions = EshopWebService.Infrastructure.Extensions.DistributedCacheExtensions;

namespace EshopWebService.Infrastructure.Repositories
{
    public class ProductCachedRepository : IProductRepository
    {
        private readonly IProductRepository _productRepository;
        private readonly IDistributedCache _distributedCache;

        public ProductCachedRepository(IProductRepository productRepository, IDistributedCache distributedCache)
        {
            _productRepository = Guard.Against.Null(productRepository, nameof(productRepository));
            _distributedCache = Guard.Against.Null(distributedCache, nameof(distributedCache));
        }

        public async Task<Product> GetByIdAsync(int productId)
        {
            var cachedKey = ProductCacheKeys.GetByIdKey(productId);
            var product = await DistributedCacheExtensions.GetAsync<Product>(_distributedCache, cachedKey);
            if (product == null)
            {
                product = await _productRepository.GetByIdAsync(productId);
                if (product == null)
                {
                    throw ApiExceptionFactory.Throw("Product Not Found.");
                }

                await DistributedCacheExtensions.SetAsync(_distributedCache, cachedKey, product);
            }

            return product;
        }

        public async Task<List<Product>> GetAsync()
        {
            var cachedKey = ProductCacheKeys.GetAllKey;
            var products = await DistributedCacheExtensions.GetAsync<List<Product>>(_distributedCache, cachedKey);
            if (products == null)
            {
                products = await _productRepository.GetAsync();

                await DistributedCacheExtensions.SetAsync(_distributedCache, cachedKey, products);
            }

            return products;
        }

        public Task<IPaginatedResultDto<Product>> GetAsync(int pageNumber, int pageSize)
        {
            return _productRepository.GetAsync(pageNumber, pageSize);
        }

        public async Task<int> CreateAsync(Product product)
        {
            await _productRepository.CreateAsync(product);

            await DistributedCacheExtensions.RemoveAsync(_distributedCache, ProductCacheKeys.GetAllKey);

            return product.Id;
        }

        public async Task UpdateAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);

            await DistributedCacheExtensions.RemoveAsync(_distributedCache, ProductCacheKeys.GetAllKey);
            await DistributedCacheExtensions.RemoveAsync(_distributedCache, ProductCacheKeys.GetByIdKey(product.Id));
        }

        public async Task DeleteAsync(Product product)
        {
            await _productRepository.DeleteAsync(product);

            await DistributedCacheExtensions.RemoveAsync(_distributedCache, ProductCacheKeys.GetAllKey);
            await DistributedCacheExtensions.RemoveAsync(_distributedCache, ProductCacheKeys.GetByIdKey(product.Id));
        }
    }
}