using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleService.Controllers.Converters.Implementations
{
    /// <summary>
    /// Faz a conversão em Produto e product
    /// </summary>
    public class ProdutoProductConverter : Abstracts.IModelControllerModelConverter<SaleService.Models.Product, Models.Produto>
    {
        public Models.Produto FromModel(SaleService.Models.Product product)
        {
            return new Models.Produto()
            {
                Id = product.Id,
                Codigo = product.Code,
                Nome = product.Name,
                Preco = product.Price,
                QuantidadeEmEstoque = product.Stock
            };
        }

        public SaleService.Models.Product ToModel(Models.Produto product)
        {
            return new SaleService.Models.Product()
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
