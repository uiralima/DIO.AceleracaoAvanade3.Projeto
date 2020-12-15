using Microsoft.EntityFrameworkCore;
using SaleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleService.Repository.Implementations
{
    /// <summary>
    /// Classe que implementa o repositório de Produtos baseada em EntityFramework
    /// </summary>
    public class EntityFrameworkProductRepository : Abstracts.BaseRepository<Models.Product, EntityFrameworkProductRepository>, Abstracts.IProductRepository
    {
        public EntityFrameworkProductRepository(DbContextOptions<EntityFrameworkProductRepository> options, Abstracts.IUnitOfWork transaction) : base(options, transaction)
        {
        }

        /// <summary>
        /// Retorna a lista de produtos com estque positivo
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Models.Product>> GetAllWithStockAsync()
        {
            return await Task.FromResult<IEnumerable<Models.Product>>(Items.Where(f => f.Stock > 0.0M).AsNoTracking());
        }
    }
}
