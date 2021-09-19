using System;
using System.Threading;
using System.Threading.Tasks;
using EshopWebService.Application.Interfaces.Repositories;
using EshopWebService.Intrastructure.DbContexts;

namespace EshopWebService.Intrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<int> Commit(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}