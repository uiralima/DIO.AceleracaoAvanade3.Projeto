using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockService.Controllers.Converters.Abstracts
{
    public interface IFactory
    {
        IModelControllerModelConverter<T, W> GetConverter<T, W>() where T : StockService.Models.IModel where W : Models.IControllerModel;
    }
}
