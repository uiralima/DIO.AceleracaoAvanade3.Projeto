using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaleService.Repository.Abstracts
{
    /// <summary>
    /// Contrato básico para o repositório de produtos
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Inserir um produto
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task<Models.Product> CreateAsync(Models.Product product);
        /// <summary>
        /// Atualizar um produto
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task<Models.Product> UpdateAsync(Models.Product product);
        /// <summary>
        /// Retorna a lista de produtos com estque positivo
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Models.Product>> GetAllWithStockAsync();
        /// <summary>
        /// Busca um produto pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Models.Product> GetAsync(string id);

        /// <summary>
        /// Apica as atualizações
        /// </summary>
        /// <returns></returns>
        Task<int> CommitAsync();

        /// <summary>
        /// Cancela as atualizações
        /// </summary>
        /// <returns></returns>
        Task RollbackAsync();
    }
}
