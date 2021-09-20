using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using EshopWebService.Application.Interfaces.Repositories;
using EshopWebService.Intrastructure.DbContexts;

namespace EshopWebService.Intrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = Guard.Against.Null(dbContext, nameof(dbContext));
        }

        public async Task<int> Commit(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}