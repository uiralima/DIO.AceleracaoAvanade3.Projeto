namespace StockService.Controllers.Converters
{
    public interface IConverterToModel<T, W> where T: StockService.Models.IModel where W: Models.IControllerModel
    {
        T ToModel(W ControllerModel);
        W FromModel(T Model);
    }
}
