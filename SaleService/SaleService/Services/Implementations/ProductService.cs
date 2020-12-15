using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaleService.Services.Implementations
{
    /// <summary>
    /// Implementa a regra de negócios do produto.
    /// </summary>
    public class ProductService : Abstracts.IProductService
    {
        /// <summary>
        /// Tópicos de notificação
        /// </summary>
        private const string SOLD_NOTIFICATION_KEY = "produtovendido";

        Repository.Abstracts.IProductRepository _repository;
        private readonly Abstracts.INotifyService _notify;

        public ProductService(Repository.Abstracts.IProductRepository repository, Abstracts.INotifyService notify)
        {
            this._repository = repository;
            this._notify = notify;
        }

        /// <summary>
        /// Valida e insere um produto
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Models.OperationResult> CreateAsync(Models.Product model)
        {
            try
            {
                model = await this._repository.CreateAsync(model);
                await this._repository.CommitAsync();
                return new Models.OperationResult();
            }
            catch (Exception ex)
            {
                await this._repository.RollbackAsync();
                throw (ex);
            }
        }

        /// <summary>
        /// Busca a lista de produtos
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Models.Product>> GetAllAsync()
        {
            return await this._repository.GetAllWithStockAsync();
        }

        /// <summary>
        /// Valida e atualiza um produto
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Models.OperationResult> UpdateAsync(Models.Product model)
        {
            try
            {
                model = await this._repository.UpdateAsync(model);
                await this._repository.CommitAsync();
                return new Models.OperationResult();
            }
            catch (Exception ex)
            {
                await this._repository.RollbackAsync();
                throw (ex);
            }
        }

        /// <summary>
        /// Valida e atualiza o estque de um produto e notifica o pipe
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public async Task<Models.OperationResult> UpdateStockAsync(Models.SaleItem item)
        {
            try
            {
                var product = await this._repository.GetAsync(item.ProductId);
                if (null != product)
                {
                    var validateReult = CheckStock(product, item.Amount);
                    if (!validateReult.Success)
                    {
                        return validateReult;
                    }
                    product.Stock -= item.Amount;
                    await this._repository.UpdateAsync(product);
                    await this._notify.Send(SOLD_NOTIFICATION_KEY, item);
                    await this._repository.CommitAsync();
                    return new Models.OperationResult();
                }
                else
                {
                    return new Models.OperationResult("Invalid Product");
                }
            }
            catch (Exception ex)
            {
                await this._repository.RollbackAsync();
                throw (ex);
            }
        }

        /// <summary>
        /// Verifica as regras de negócio do estoque do produto
        /// </summary>
        /// <param name="product"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        private Models.OperationResult CheckStock(Models.Product product, decimal amount)
        {
            if (product.Stock < amount)
            {
                return new Models.OperationResult($"Insufficient Stock to {product.Name}");
            }
            return new Models.OperationResult();
        }
    }
}
