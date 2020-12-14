using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockService.Services.Abstracts.Converter
{
    public interface IModelJSONConverter
    {
        string ToJSON(object model);
        T FromJSON<T>(string json) where T : class;
    }
}
