using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockService.Controllers.Converters.Abstracts
{
    public interface IModelControllerModelConverter<T, W> where T : StockService.Models.IModel where W : Models.IControllerModel
    {
        T ToModel(W ControllerModel);
        W FromModel(T Model);
    }
}
