using Microsoft.EntityFrameworkCore;
using StockService.Repository.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockService.Repository.Implementations
{
    public class EntityFrameworkProductRepository: Abstracts.BaseRepository<Models.Product, EntityFrameworkProductRepository>, Abstracts.IProductRepository
    {
        public EntityFrameworkProductRepository(DbContextOptions<EntityFrameworkProductRepository> options, Abstracts.IUnitOfWork transaction) : base(options, transaction)
        {
        }
        public async Task<bool> SameNameOrCodeAsync(string name, string code, string id)
        {
            return await Items.AsNoTracking().AnyAsync(f => ((f.Name.ToUpper() == name.ToUpper() || f.Code.ToUpper() == code.ToUpper()) && (f.Id != id)));
        }
    }
}
