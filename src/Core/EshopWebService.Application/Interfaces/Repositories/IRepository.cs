using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopWebService.Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> AsQueryable { get; }
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(int pageNumber, int pageSize);
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}