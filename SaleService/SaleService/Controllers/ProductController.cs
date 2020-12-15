using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleService.Controllers
{
    /// <summary>
    /// Controlador do produto
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private Services.Abstracts.IProductService _productService;
        private Converters.Abstracts.IFactory _converterFactory;
        public ProductController(Services.Abstracts.IProductService productService, Converters.Abstracts.IFactory converterFactory)
        {
            this._productService = productService;
            this._converterFactory = converterFactory;
        }

        /// <summary>
        /// Lista todos os produtos em estoque
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Produto>>> GetAll()
        {
            try
            {
                // O método extendido FromModel vem do Factory de converter que está em StockService.Controllers.Converters
                return Ok((await this._productService.GetAllAsync()).Select(f => this._converterFactory.GeToControllerConverter<SaleService.Models.Product, Models.Produto>().FromModel(f)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
