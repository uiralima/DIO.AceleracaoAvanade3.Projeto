using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleService.Controllers.Converters.Abstracts
{
    /// <summary>
    /// Contrato para conversão nos 2 sentidos entre o modelo de dados e o modelo de negócio
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="W"></typeparam>
    public interface IModelControllerModelConverter<T, W>: IModelToControllerConverter<T, W>, IControllerToModelConverter<T, W> where T : SaleService.Models.IModel where W : Models.IControllerModel
    {
    }
}
