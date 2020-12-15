namespace StockService.Services.Abstracts.Converter
{
        /// <summary>
        /// Interface para conversores de model de dados do serviço para Byte[] e vice versa
        /// </summary>
        public interface IModelByteConverter
        {
            /// <summary>
            /// Inica o content type da serialização que será aplicada
            /// </summary>
            string CotentType { get; }

            /// <summary>
            /// Serializa e converte o objeto serializado para byte[]
            /// </summary>
            /// <param name="model"></param>
            /// <returns></returns>
            byte[] ToBytes(object model);

            /// <summary>
            /// Recupera o objeto de um byte[]
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="data"></param>
            /// <returns></returns>
            T FromBytes<T>(byte[] data) where T : class;
        }
}
