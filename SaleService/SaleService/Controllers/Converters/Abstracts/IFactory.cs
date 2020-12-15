using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleService.Controllers.Converters.Abstracts
{
    /// <summary>
    /// Contrato para fabrica de conversores
    /// </summary>
    public interface IFactory
    {
        IControllerToModelConverter<T, W> GeToModelConverter<T, W>() where T : SaleService.Models.IModel where W : Models.IControllerModel;
        IModelToControllerConverter<T, W> GeToControllerConverter<T, W>() where T : SaleService.Models.IModel where W : Models.IControllerModel;
    }
}
