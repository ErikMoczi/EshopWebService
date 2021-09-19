using System.Threading;
using System.Threading.Tasks;

namespace EshopWebService.Application.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> Commit(CancellationToken cancellationToken);
    }
}