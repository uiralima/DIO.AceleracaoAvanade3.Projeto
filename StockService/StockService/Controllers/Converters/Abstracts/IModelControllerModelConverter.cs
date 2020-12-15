namespace StockService.Controllers.Converters.Abstracts
{
    /// <summary>
    /// Contrato para Conversores de modelo de dados em modelo de controller e vice versa
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="W"></typeparam>
    public interface IModelControllerModelConverter<T, W> where T : StockService.Models.IModel where W : Models.IControllerModel
    {
        /// <summary>
        /// Converte modelo de controller em modelo de dados
        /// </summary>
        /// <param name="controllerModel"></param>
        /// <returns></returns>
        T ToModel(W controllerModel);

        /// <summary>
        /// Cria um modelo de controler a partid de um modelo de dados
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        W FromModel(T model);
    }
}
