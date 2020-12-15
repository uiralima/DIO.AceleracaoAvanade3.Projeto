using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockService.Services.Implementations
{
    /// <summary>
    /// Implementa a regra de negócios do produto.
    /// </summary>
    public class ProductService : Abstracts.IProductService
    {
        /// <summary>
        /// Tópicos de notificação
        /// </summary>
        private const string CREATE_NOTIFICATION_KEY = "produtocriado";
        private const string UPDATE_NOTIFICATION_KEY = "produtoatualizado";

        Repository.Abstracts.IProductRepository _repository;
        private readonly Abstracts.INotifyService _notify;

        public ProductService(Repository.Abstracts.IProductRepository repository, Abstracts.INotifyService notify)
        {
            this._repository = repository;
            this._notify = notify;
        }

        /// <summary>
        /// Valida e insere um produto e notifica o pipe
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Models.OperationResult> CreateAsync(Models.Product model)
        {
            try
            {
                // Valida se o produt está de acordo com as regras e negócio
                var validateResut = await ValidateProduct(model);
                if (!validateResut.Success)
                {
                    return validateResut;
                }
                // Insere o produto
                model = await this._repository.CreateAsync(model);
                // Envia a notificação
                await this._notify.Send(CREATE_NOTIFICATION_KEY, model);
                // Aplica os dados
                await this._repository.CommitAsync();
                return new Models.OperationResult();
            }
            catch(Exception ex)
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
            return await this._repository.GetAllAsync();
        }

            /// <summary>
            /// Valida e atualiza um produto e envia a notificação
            /// </summary>
            /// <param name="model"></param>
            /// <returns></returns>
        public async Task<Models.OperationResult> UpdateAsync(Models.Product model)
        {
            try
            {
                // Valida se o produt está de acordo com as regras e negócio
                var validateResut = await ValidateProduct(model);
                if (!validateResut.Success)
                {
                    return validateResut;
                }
                // Atualiza um produto caso o mesmo exista
                model = await this._repository.UpdateAsync(model);
                if (model != default)
                {
                    // Envia a notificação
                    await this._notify.Send(UPDATE_NOTIFICATION_KEY, model);
                    // Aplica as alterações
                    await this._repository.CommitAsync();
                    return new Models.OperationResult();
                }
                else 
                {
                    return new Models.OperationResult("Invalid Product!");
                }
            }
            catch (Exception ex)
            {
                await this._repository.RollbackAsync();
                throw (ex);
            }
        }

        /// <summary>
        /// Atualiza o estque de um produto
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Verifica se o produto está de acordo com as regras de negócio
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
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
