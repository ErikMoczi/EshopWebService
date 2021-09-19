using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopWebService.Application.Interfaces.Repositories;
using EshopWebService.Intrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace EshopWebService.Intrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IQueryable<T> AsQueryable => _dbContext.Set<T>();

        private DbSet<T> DbSet => _dbContext.Set<T>();

        public async Task<T> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await DbSet
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
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