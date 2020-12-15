namespace SaleService.Controllers.Converters.Abstracts
{
    /// <summary>
    /// Contrato para converter de um modelo de controller para um modelo de dados
    /// </summary>
    /// <typeparam name="T">SaleService.Models.IModel</typeparam>
    /// <typeparam name="W">Models.IControllerModel</typeparam>
    public interface IControllerToModelConverter<T, W> where T : SaleService.Models.IModel where W : Models.IControllerModel
    {
        T ToModel(W controllerModel);
    }
}
