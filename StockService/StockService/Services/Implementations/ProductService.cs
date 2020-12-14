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

        Repository.Abstracts.IProductRepository _repository;
        private readonly Abstracts.INotifyService _notify;

        public ProductService(Repository.Abstracts.IProductRepository repository, Abstracts.INotifyService notify)
        {
            this._repository = repository;
            this._notify = notify;
        }
        public async Task<Models.OperationResult> CreateAsync(Models.Product model)
        {
            try
            {
                var validateResut = await ValidateProduct(model);
                if (!validateResut.Success)
                {
                    return validateResut;
                }
                model = await this._repository.CreateAsync(model);
                await this._repository.CommitAsync();
                await this._notify.Send(CREATE_NOTIFICATION_KEY, model);
                return new Models.OperationResult();
            }
            catch(Exception ex)
            {
                await this._repository.RollbackAsync();
                throw (ex);
            }
        }

        public async Task<IEnumerable<Models.Product>> GetAllAsync()
        {
            return await this._repository.GetAllAsync();
        }

        public async Task<Models.OperationResult> UpdateAsync(Models.Product model)
        {
            try
            {
                var validateResut = await ValidateProduct(model);
                if (!validateResut.Success)
                {
                    return validateResut;
                }
                model = await this._repository.UpdateAsync(model);
                await this._repository.CommitAsync();
                await this._notify.Send(UPDATE_NOTIFICATION_KEY, model);
                return new Models.OperationResult();
            }
            catch (Exception ex)
            {
                await this._repository.RollbackAsync();
                throw (ex);
            }
        }

        public async Task<Models.OperationResult> UpdateStockAsync(string productId, decimal amount)
        {
            try
            {
                var product = await this._repository.GetAsync(productId);
                product.Stock -= amount;
                await this._repository.UpdateAsync(product);
                await this._repository.CommitAsync();
                return new Models.OperationResult();
            }
            catch (Exception ex)
            {
                await this._repository.RollbackAsync();
                throw (ex);
            }
        }

        private async Task<Models.OperationResult> ValidateProduct(Models.Product product)
        {
            if (await this._repository.SameNameOrCodeAsync(product.Name, product.Code, product.Id))
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
    }
}
