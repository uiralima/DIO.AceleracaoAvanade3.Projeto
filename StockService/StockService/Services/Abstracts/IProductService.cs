using System.Collections.Generic;

namespace StockService.Services.Abstracts
{
    public interface IProductService
    {
        void Create(Models.Product product);
        void Update(Models.Product product);
        IEnumerable<Models.Product> Get();
    }
}
