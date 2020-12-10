using System;

namespace StockService.Controllers.Converters
{
    public static class ConverterFactory
    {
        public static StockService.Models.IModel ToModel(this Models.IControllerModel controllerModel)
        {
            string typeName = controllerModel.GetType().Name;
            if (typeName.Equals("Produto"))
            {
                return new ProdutoProductConverter().ToModel((Models.Produto)controllerModel);
            }
            else
            {
                throw new Exception("Invalid Controller Model Type");
            }
        }

        public static Models.IControllerModel FromModel(this StockService.Models.IModel model)
        {
            string typeName = model.GetType().Name;
            if (typeName.Equals("Product"))
            {
                return new ProdutoProductConverter().FromModel((StockService.Models.Product)model);
            }
            else
            {
                throw new Exception("Invalid Model Type");
            }
        }
    }
}
