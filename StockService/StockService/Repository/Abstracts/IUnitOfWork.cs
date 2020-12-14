using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace StockService.Repository.Abstracts
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync(DbContext context, CancellationToken cancellationToken = default);
        Task RollbackAsync(DbContext context, CancellationToken cancellationToken = default);
    }
}
