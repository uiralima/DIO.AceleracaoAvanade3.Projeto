namespace StockService.Services.Abstracts
{
    public interface IModelUpdate<T> where T: Models.IModel
    {
        Models.OperationResult Update(T model);
    }
}
