using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace StockService.Repository.Abstracts
{
    public abstract class BaseRepository<T, K> : DbContext where T : class, Models.IModel  where K : BaseRepository<T, K>
    {
        public BaseRepository(DbContextOptions<K> options)
            : base(options)
        { }
        protected DbSet<T> Items { get; set; }

        public void Create(T item)
        {
            this.Items.Add(item);
            this.SaveChanges();
        }

        public void Update(T item)
        {
            this.Items.Update(item);
            this.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return this.Items.ToArray();
        }
    }

}
