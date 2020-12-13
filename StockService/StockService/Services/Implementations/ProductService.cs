using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockService.Services.Implementations
{
    public class ProductService : Abstracts.IProductService
    {
        private const string CREATE_NOTIFICATION_KEY = "produtocriado";
        private const string UPDATE_NOTIFICATION_KEY = "produtoatualizado";
        private readonly Abstracts.INotifyService _notify;

        private Repository.Abstracts.IProductRepository _dbContext;
        public ProductService(Abstracts.INotifyService notify, Repository.Abstracts.IProductRepository dbContext)
        {
            this._notify = notify;
            this._dbContext = dbContext;
        }
        private Models.OperationResult ValidateProduct(Models.Product product)
        {
            if (this._dbContext.SameNameOrCode(product.Name, product.Code))
            {
                return new Models.OperationResult("Already exists a product with the same name or code");
            }
            if (product.Price < 0.0M)
            {
                return new Models.OperationResult("Price must be greater or equals 0");
            }
            if (product.Stock < 0.0M)
            {
                return new Models.OperationResult("Stock must be greater or equals 0");
            }
            return new Models.OperationResult();
        }
        public Models.OperationResult Create(Models.Product product)
        {
            var validateResut = ValidateProduct(product);
            if (!validateResut.Success)
            {
                return validateResut;
            }
            this._dbContext.Create(product);
            this._notify.Send(CREATE_NOTIFICATION_KEY, product);
            return new Models.OperationResult();
        }
        public IEnumerable<Models.Product> GetAll()
        {
            return this._dbContext.GetAll();
        }
        public Models.OperationResult Update(Models.Product product)
        {
            var validateResut = ValidateProduct(product);
            if (!validateResut.Success)
            {
                return validateResut;
            }
            this._dbContext.Update(product);
            this._notify.Send(UPDATE_NOTIFICATION_KEY, product);
            return new Models.OperationResult();
        }

        public Models.OperationResult UpdateStock(int productId, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
