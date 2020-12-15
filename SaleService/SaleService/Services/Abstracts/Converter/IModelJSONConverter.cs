namespace SaleService.Services.Abstracts.Converter
{
    /// <summary>
    /// Contrato para conversores de modelo de dados em JSON
    /// </summary>
    public interface IModelJSONConverter
    {
        /// <summary>
        /// Converte um ubjeto em um JSON
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        string ToJSON(object model);

        /// <summary>
        /// Cria uma instância do objeto a partir de seu JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        T FromJSON<T>(string json) where T : class;
    }
}
