using SaleService.Controllers.Models;
using SaleService.Models;

namespace SaleService.Controllers.Converters.Implementations
{
   /// <summary>
   /// Converte um ItemVenda em um SaleItem
   /// </summary>
    public class ItemVendaSaleItemConverter : Abstracts.IControllerToModelConverter<SaleService.Models.SaleItem, SaleService.Controllers.Models.ItemVenda>
    {
        public SaleItem ToModel(ItemVenda controllerModel)
        {
            return new SaleService.Models.SaleItem()
            { 
                ProductId = controllerModel.IdProduto,
                Amount = controllerModel.QuantidadeVedida
            };
        }
    }
}
