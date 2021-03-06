﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockService.Repository.Abstracts
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
        /// Busca a lista de produtos
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Models.Product>> GetAllAsync();

        /// <summary>
        /// Busca um produto pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Models.Product> GetAsync(string id);

        /// <summary>
        /// Verifica se já existe um produto com o mesmo nome ou código
        /// </summary>
        /// <param name="name">Nome</param>
        /// <param name="code">Código</param>
        /// <param name="id">Id</param>
        /// <returns>Existe/Não existe</returns>
        Task<bool> SameNameOrCodeAsync(string name, string code, string id);

        /// <summary>
        /// AApica as atualizações
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
