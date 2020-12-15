using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleService.Controllers.Converters.Abstracts
{
    /// <summary>
    /// Contrato para converter de um modelo de dados para um modelo de controller
    /// </summary>
    /// <typeparam name="T">SaleService.Models.IModel</typeparam>
    /// <typeparam name="W">Models.IControllerModel</typeparam>
    public interface IModelToControllerConverter<T, W> where T : SaleService.Models.IModel where W : Models.IControllerModel
    {
        W FromModel(T model);
    }
}
