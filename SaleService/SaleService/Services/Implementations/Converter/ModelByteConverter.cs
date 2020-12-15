using System.Text;

namespace SaleService.Services.Implementations.Converter
{
    /// <summary>
    /// Implementa a conversão entre um objeto e um byte[] serializando com JSON
    /// </summary>
    public class ModelByteConverter : Abstracts.Converter.IModelByteConverter
    {
        private readonly UTF8Encoding Utf8NoBom = new UTF8Encoding(false);
        private Abstracts.Converter.IModelJSONConverter _jsonConverter;
        public ModelByteConverter(Abstracts.Converter.IModelJSONConverter jsonConverter)
        {
            this._jsonConverter = jsonConverter;
        }

        /// <summary>
        /// Tipo de serialização(JSON)
        /// </summary>
        public string CotentType => "application/json";

        /// <summary>
        /// Serializa e converte o objeto serializado para byte[]
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public T FromBytes<T>(byte[] data) where T : class
        {
            return this._jsonConverter.FromJSON<T>(Utf8NoBom.GetString(data));
        }

        /// <summary>
        /// Recupera o objeto de um byte[]
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public byte[] ToBytes(object model)
        {
            return Utf8NoBom.GetBytes(this._jsonConverter.ToJSON(model));
        }
    }
}
