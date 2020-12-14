using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StockService.Repository.Implementations
{
    public class UnitOfWork : Abstracts.IUnitOfWork
    {
        public Task<int> CommitAsync(DbContext context, CancellationToken cancellationToken = default)
        {
            return context.SaveChangesAsync();
        }

        public Task RollbackAsync(DbContext context, CancellationToken cancellationToken = default)
        {
            context.ChangeTracker.Entries()
                .Where(e => e.Entity != null).ToList()
                .ForEach(e => e.State = EntityState.Detached);

            return Task.CompletedTask;
        }
    }
}
