using StockService.Controllers.Converters.Abstracts;
using System;

namespace StockService.Controllers.Converters.Implementations
{
    /// <summary>
    /// Implementa a fábrica de conversores 
    /// </summary>
    public class Factory : Abstracts.IFactory
    {
        /// <summary>
        /// Retorna o conversor de acordo com os dados informados
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="W"></typeparam>
        /// <returns></returns>
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
