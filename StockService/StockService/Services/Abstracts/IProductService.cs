using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockService.Services.Abstracts
{
    public interface IProductService
    {
        Task<Models.OperationResult> UpdateAsync(Models.Product model);
        Task<IEnumerable<Models.Product>> GetAllAsync();
        Task<Models.OperationResult> CreateAsync(Models.Product model);
        Task<Models.OperationResult> UpdateStockAsync(string productId, decimal amount);
    }
}
