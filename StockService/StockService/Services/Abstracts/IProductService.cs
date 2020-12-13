using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockService.Services.Abstracts
{
    public interface IProductService : IModelCreate<Models.Product>, IModelUpdate<Models.Product>, IModelRead<Models.Product>
    {
        Models.OperationResult UpdateStock(int productId, decimal amount);
    }
}
