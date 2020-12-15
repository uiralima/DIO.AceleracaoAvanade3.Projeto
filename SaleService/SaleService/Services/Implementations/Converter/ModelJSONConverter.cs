using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace SaleService.Services.Implementations.Converter
{
    /// <summary>
    /// Imlementa a serialização/deserualização de um objeto utilizando JSON
    /// </summary>
    public class ModelJSONConverter : Abstracts.Converter.IModelJSONConverter
    {
        /// <summary>
        /// Configurações de serialização
        /// </summary>
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

        /// <summary>
        /// Cria uma instância do objeto a partir de seu JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public T FromJSON<T>(string json) where T : class
        {
            if (json == null || json.Length == 0) return default;
            var result = JsonConvert.DeserializeObject<T>(json, JsonSettings);
            return result;
        }

        /// <summary>
        /// Converte um ubjeto em um JSON
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string ToJSON(object model)
        {
            return JsonConvert.SerializeObject(model, Formatting.Indented, JsonSettings);
        }
    }
}
