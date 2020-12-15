using StockService.Controllers.Models;
using StockService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockService.Controllers.Converters.Implementations
{
    /// <summary>
    /// Implemeta um conversor entre Model.Products e Controller.Models.Produtos
    /// </summary>
    public class ProdutoProductConverter: Abstracts.IModelControllerModelConverter<StockService.Models.Product, Models.Produto>
    {
        /// <summary>
        /// Converte um Controller.Models.Produtos em um Model.Products 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public Produto FromModel(Product product)
        {
            return new Produto()
            {
                Id = product.Id,
                Codigo = product.Code,
                Nome = product.Name,
                Preco = product.Price,
                QuantidadeEmEstoque = product.Stock
            };
        }


        /// <summary>
        /// Cria uma instancia de Controller.Models.Produtos a partir de um Model.Products 
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        public StockService.Models.Product ToModel(Models.Produto produto)
        {
            return new StockService.Models.Product()
            {
                Id = produto.Id,
                Code = produto.Codigo,
                Name = produto.Nome,
                Price = produto.Preco,
                Stock = produto.QuantidadeEmEstoque
            };
        }
    }
}
