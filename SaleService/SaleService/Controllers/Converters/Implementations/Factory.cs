using SaleService.Controllers.Converters.Abstracts;
using SaleService.Controllers.Models;
using SaleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleService.Controllers.Converters.Implementations
{
    /// <summary>
    /// Implementação da fábrica de cnversores
    /// </summary>
    public class Factory : Abstracts.IFactory
    {
        /// <summary>
        /// Instancia o conversor correto para cnverter um modelo de dados em um modelo de controller
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="W"></typeparam>
        /// <returns>Conversor</returns>
        public IModelToControllerConverter<T, W> GeToControllerConverter<T, W>()
            where T : IModel
            where W : IControllerModel
        {
            if (typeof(T).Equals(typeof(SaleService.Models.Product)))
            {
                if (typeof(W).Equals(typeof(Models.Produto)))
                {
                    return (Abstracts.IModelToControllerConverter<T, W>)(new ProdutoProductConverter());
                }
            }
            throw new Exception("Invalid Conversion");
        }

        /// <summary>
        /// Instancia o conversor correto para cnverter um modelo de controller em um modelo de dados
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="W"></typeparam>
        /// <returns>Conversor</returns>
        public IControllerToModelConverter<T, W> GeToModelConverter<T, W>()
            where T : IModel
            where W : IControllerModel
        {
            if (typeof(T).Equals(typeof(SaleService.Models.Product)))
            {
                if (typeof(W).Equals(typeof(Models.Produto)))
                {
                    return (Abstracts.IControllerToModelConverter<T, W>)(new ProdutoProductConverter());
                }
            }
            if (typeof(T).Equals(typeof(SaleService.Models.SaleItem)))
            {
                if (typeof(W).Equals(typeof(Models.ItemVenda)))
                {
                    return (IControllerToModelConverter<T, W>)new ItemVendaSaleItemConverter();
                }
            }
            throw new Exception("Invalid Conversion");
        }
    }
}
