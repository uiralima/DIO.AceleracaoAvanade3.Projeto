using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaleService.Services.Abstracts
{
    /// <summary>
    /// Contrato para serviços que traalharão co produtos
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Atualiza um produto
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Models.OperationResult> UpdateAsync(Models.Product model);
        /// <summary>
        /// Busca a lista de produtos
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Models.Product>> GetAllAsync();
        /// <summary>
        /// Insere um produto
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Models.OperationResult> CreateAsync(Models.Product model);
        /// <summary>
        /// Atualiza o estoque do produto
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        Task<Models.OperationResult> UpdateStockAsync(Models.SaleItem item);
    }
}
