using System;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using EshopWebService.Application.Interfaces.Repositories;
using EshopWebService.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace EshopWebService.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = Guard.Against.Null(dbContext, nameof(dbContext));
        }

        private DbSet<T> DbSet => _dbContext.Set<T>();

        public Task<TResult> AsQueryableAsync<TResult>(Func<IQueryable<T>, Task<TResult>> action)
        {
            return action(DbSet);
        }

        public async Task<T> CreateAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            return entity;
        }

        public Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(T entity)
        {
            DbSet.Remove(entity);
            return Task.CompletedTask;
        }
    }
}