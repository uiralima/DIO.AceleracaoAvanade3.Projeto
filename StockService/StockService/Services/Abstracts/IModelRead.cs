using System.Collections.Generic;

namespace StockService.Services.Abstracts
{
    public interface IModelRead<T> where T : Models.IModel
    {
        IEnumerable<Models.Product> GetAll();
    }
}
