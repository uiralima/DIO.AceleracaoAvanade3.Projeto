using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleService.Controllers.Converters
{
    public class ProdutoProductConverter : IConverterToModel<SaleService.Models.Product, Models.Produto>
    {
        public Models.Produto FromModel(SaleService.Models.Product product)
        {
            return new Models.Produto()
            {
                ID = product.Id,
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
                ID = product.ID,
                Code = product.Codigo,
                Name = product.Nome,
                Price = product.Preco,
                Stock = product.QuantidadeEmEstoque
            };
        }
    }
}
