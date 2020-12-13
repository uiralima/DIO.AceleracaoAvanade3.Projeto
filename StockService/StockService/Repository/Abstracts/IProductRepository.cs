using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockService.Repository.Abstracts
{
    public interface IProductRepository
    {
        void Create(Models.Product product);
        void Update(Models.Product product);
        IEnumerable<Models.Product> GetAll();
        bool SameNameOrCode(string name, string code);
    }
}
