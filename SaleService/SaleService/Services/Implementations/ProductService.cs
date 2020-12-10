using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleService.Services.Implementations
{
    public class ProductService : Abstracts.IProductService
    {
        private Dictionary<int, Models.Product> _products = new Dictionary<int, Models.Product>();
        public void Create(Models.Product product)
        {
            this._products.Add(product.ID, product);
        }

        public IEnumerable<Models.Product> Get()
        {
            return this._products.Select(f => f.Value).Where(f => f.Stock > 0.0M);
        }

        public void Update(Models.Product product)
        {
            this._products[product.ID] = product;
        }
    }
}
