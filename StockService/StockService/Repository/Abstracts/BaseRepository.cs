using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StockService.Repository.Abstracts
{
    public abstract class BaseRepository<T, K> : DbContext where T : class, Models.IModel  where K : BaseRepository<T, K>
    {
        IUnitOfWork _transaction;
        public BaseRepository(DbContextOptions<K> options, IUnitOfWork _transaction)
            : base(options)
        {
            this._transaction = _transaction;
        }
        protected DbSet<T> Items { get; set; }

        public async Task<T> CreateAsync(T item)
        {
            item.Id = Guid.NewGuid().ToString();
            await this.Items.AddAsync(item);
            return item;
        }

        public async Task<T> UpdateAsync(T item)
        {
            if (await Items.AnyAsync(o => o.Id.Equals(item.Id)))
            {
                this.Entry(item).State = EntityState.Modified;
                return item;
            }
            else 
            {
                return default;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.FromResult<IEnumerable<T>>(Items.AsNoTracking());
        }

        public async Task<T> GetAsync(string id)
        {
            return await Items.AsNoTracking().FirstOrDefaultAsync(o => o.Id.Equals(id));
        }

        public async Task<int> CommitAsync()
        {
            return await this._transaction.CommitAsync(this);
        }

        public async Task RollbackAsync()
        {
            await this._transaction.RollbackAsync(this);
        }
    }

}
