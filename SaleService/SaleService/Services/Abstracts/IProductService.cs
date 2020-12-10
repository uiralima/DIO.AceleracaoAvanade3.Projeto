using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleService.Services.Abstracts
{
    public interface IProductService
    {
        void Create(Models.Product product);
        void Update(Models.Product product);
        IEnumerable<Models.Product> Get();
    }
}
