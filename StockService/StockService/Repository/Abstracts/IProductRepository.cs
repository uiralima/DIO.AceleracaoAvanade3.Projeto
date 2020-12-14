using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockService.Repository.Abstracts
{
    public interface IProductRepository   
    {
        Task<Models.Product> CreateAsync(Models.Product product);
        Task<Models.Product> UpdateAsync(Models.Product product);
        Task<IEnumerable<Models.Product>> GetAllAsync();
        Task<Models.Product> GetAsync(string id);
        Task<bool> SameNameOrCodeAsync(string name, string code, string id);
        Task<int> CommitAsync();
        Task RollbackAsync();
    }
}
