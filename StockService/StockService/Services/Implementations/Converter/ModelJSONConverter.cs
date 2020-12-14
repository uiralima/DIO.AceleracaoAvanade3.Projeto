using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using StockService.Models;
using System;

namespace StockService.Services.Implementations.Converter
{
    public class ModelJSONConverter : Abstracts.Converter.IModelJSONConverter
    {
        private readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            DateFormatHandling = DateFormatHandling.IsoDateFormat,
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            TypeNameHandling = TypeNameHandling.None,
            Converters = new JsonConverter[] { new StringEnumConverter() }
        };
        public T FromJSON<T>(string json) where T : class
        {
            if (json == null || json.Length == 0) return default;
            var result = JsonConvert.DeserializeObject<T>(json, JsonSettings);
            return result;
        }

        public string ToJSON(object model)
        {
            return JsonConvert.SerializeObject(model, Formatting.Indented, JsonSettings);
        }
    }
}
