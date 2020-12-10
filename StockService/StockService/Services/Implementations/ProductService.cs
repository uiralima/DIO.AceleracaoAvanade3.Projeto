using System;
using System.Collections.Generic;
using System.Linq;

namespace StockService.Services.Implementations
{
    public class ProductService : Abstracts.IProductService
    {
        private Dictionary<int, Models.Product> _products = new Dictionary<int, Models.Product>();

        private const string CREATE_NOTIFICATION_KEY = "produtocriado";
        private const string UPDATE_NOTIFICATION_KEY = "produtoatualizado";
        private readonly Abstracts.INotifyService _notify;
        public ProductService(Abstracts.INotifyService notify)
        {
            this._notify = notify;
        }
        public void Create(Models.Product product)
        {
            //TODO: Regra de negócio aqui
            product.ID = this._products.Count + 1;
            this._products.Add(product.ID, product);
            this._notify.Send(CREATE_NOTIFICATION_KEY, product);
        }

        public IEnumerable<Models.Product> Get()
        {
            return this._products.Select(f => f.Value);
        }

        public void Update(Models.Product product)
        {
            //TODO: Regra de negócio aqui
            this._products[product.ID] = product;
            this._notify.Send(UPDATE_NOTIFICATION_KEY, product);
        }
    }
}
