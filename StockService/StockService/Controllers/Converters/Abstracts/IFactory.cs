namespace StockService.Controllers.Converters.Abstracts
{
    /// <summary>
    /// Contrato para fábrica de conversores
    /// </summary>
    public interface IFactory
    {
        /// <summary>
        /// Recupera o conversor correto de modelo de dados em modelo de controller e vice versa
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="W"></typeparam>
        /// <returns>Conversor</returns>
        IModelControllerModelConverter<T, W> GetConverter<T, W>() where T : StockService.Models.IModel where W : Models.IControllerModel;
    }
}
