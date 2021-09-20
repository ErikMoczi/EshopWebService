using System.Collections.Generic;
using System.Threading.Tasks;
using EshopWebService.Application.DTOs.Result;
using EshopWebService.Domain.Entities;

namespace EshopWebService.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int productId);
        Task<List<Product>> GetAsync();
        Task<IPaginatedResultDto<Product>> GetAsync(int pageNumber, int pageSize);
        Task<int> CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
    }
}