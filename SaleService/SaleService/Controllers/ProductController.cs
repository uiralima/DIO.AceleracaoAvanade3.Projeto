using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaleService.Controllers.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Services.Abstracts.IProductService _productService;
        public ProductController(Services.Abstracts.IProductService productService, Services.Abstracts.INotifiedService notifiedService)
        {
            this._productService = productService;
        }

        [HttpGet]
        public IEnumerable<Models.Produto> Get()
        {
            // O método extendido FromModel vem do Factory de converter que está em StockService.Controllers.Converters
            return this._productService.Get().Select(f => (Models.Produto)f.FromModel());
        }
    }
}
