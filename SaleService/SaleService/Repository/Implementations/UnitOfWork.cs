using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SaleService.Repository.Implementations
{
    /// <summary>
    /// Iplementa o controle de transações
    /// </summary>
    public class UnitOfWork : Abstracts.IUnitOfWork
    {
        /// <summary>
        /// Aplica uma transação
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> CommitAsync(DbContext context, CancellationToken cancellationToken = default)
        {
            var result = await context.SaveChangesAsync();
            context.ChangeTracker.Entries()
                .Where(e => e.Entity != null).ToList()
                .ForEach(e => e.State = EntityState.Detached);
            return result;
        }

        /// <summary>
        /// Cancela uma transação
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task RollbackAsync(DbContext context, CancellationToken cancellationToken = default)
        {
            context.ChangeTracker.Entries()
                .Where(e => e.Entity != null).ToList()
                .ForEach(e => e.State = EntityState.Detached);

            return Task.CompletedTask;
        }
    }
}
