namespace StockService.Services.Abstracts
{
    public interface IModelCreate<T> where T : Models.IModel
    {
        Models.OperationResult Create(T model);
    }
}
