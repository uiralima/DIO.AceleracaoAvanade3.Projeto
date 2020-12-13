using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockService.Repository.Implementations
{
    public class EntityFrameworkProductRepository: Abstracts.BaseRepository<Models.Product, EntityFrameworkProductRepository>, Abstracts.IProductRepository
    {
        public EntityFrameworkProductRepository(DbContextOptions<EntityFrameworkProductRepository> options) : base(options)
        {
        }

        public bool SameNameOrCode(string name, string code)
        {
            return this.Items.Any<Models.Product>(f => f.Name.ToUpper() == name.ToUpper() || f.Code.ToUpper() == code.ToUpper());
        }
    }
}
