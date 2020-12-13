using StockService.Controllers.Converters.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockService.Controllers.Converters.Implementations
{
    public class ConverterFactory : Abstracts.IFactory
    {
        public IModelControllerModelConverter<T, W> GetConverter<T, W>() where T : StockService.Models.IModel where W : Models.IControllerModel
        {
            if (typeof(T).Equals(typeof(StockService.Models.Product)))
            {
                if (typeof(W).Equals(typeof(Models.Produto)))
                {
                    return (Abstracts.IModelControllerModelConverter<T, W>)(new ProdutoProductConverter());
                }
            }
            throw new Exception("Invalid Conversion");
        }
    }
}
