using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace SaleService.Repository.Abstracts
{
    /// <summary>
    /// Classe abstrata de acesso ao banco de dados
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="K"></typeparam>
    public abstract class BaseRepository<T, K> : DbContext where T : class, Models.IIdModel where K : BaseRepository<T, K>
    {
        IUnitOfWork _transaction;
        public BaseRepository(DbContextOptions<K> options, IUnitOfWork transaction)
            : base(options)
        {
            this._transaction = transaction;
        }
        protected DbSet<T> Items { get; set; }

        /// <summary>
        /// Insere um dado
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<T> CreateAsync(T item)
        {
            if (String.IsNullOrEmpty(item.Id))
            {
                item.Id = Guid.NewGuid().ToString();
            }
            await this.Items.AddAsync(item);
            return item;
        }

        /// <summary>
        /// Atualiza um dado
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Busca um item específico baseado no seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetAsync(string id)
        {
            return await Items.AsNoTracking().FirstOrDefaultAsync(o => o.Id.Equals(id));
        }

        /// <summary>
        /// Aplica as alterações
        /// </summary>
        /// <returns></returns>
        public async Task<int> CommitAsync()
        {
            return await this._transaction.CommitAsync(this);
        }

        /// <summary>
        /// Discarta as alterações
        /// </summary>
        /// <returns></returns>
        public async Task RollbackAsync()
        {
            await this._transaction.RollbackAsync(this);
        }
    }
}
