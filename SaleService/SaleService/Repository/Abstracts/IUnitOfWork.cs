using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace SaleService.Repository.Abstracts
{
    /// <summary>
    /// Contrato para o controle de transação
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Aplica uma transação
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> CommitAsync(DbContext context, CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancela uma transação
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task RollbackAsync(DbContext context, CancellationToken cancellationToken = default);
    }
}
