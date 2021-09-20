using System;
using System.Linq;
using System.Threading.Tasks;

namespace EshopWebService.Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<TResult> AsQueryableAsync<TResult>(Func<IQueryable<T>, Task<TResult>> action);
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}