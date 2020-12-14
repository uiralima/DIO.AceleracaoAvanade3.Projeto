using StockService.Controllers.Models;
using StockService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockService.Controllers.Converters.Implementations
{
    public class ProdutoProductConverter: Abstracts.IModelControllerModelConverter<StockService.Models.Product, Models.Produto>
    {
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

        public StockService.Models.Product ToModel(Models.Produto product)
        {
            return new StockService.Models.Product()
            {
                Id = product.Id,
                Code = product.Codigo,
                Name = product.Nome,
                Price = product.Preco,
                Stock = product.QuantidadeEmEstoque
            };
        }
    }
}
