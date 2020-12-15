using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleService.Controllers
{
    /// <summary>
    /// Controlador da venda
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private Services.Abstracts.IProductService _productService;
        private Converters.Abstracts.IFactory _converterFactory;
        public SaleController(Services.Abstracts.IProductService productService, Converters.Abstracts.IFactory converterFactory)
        {
            this._productService = productService;
            this._converterFactory = converterFactory;
        }
        /// <summary>
        /// Recebe informação da venda de um produto
        /// </summary>
        /// <param name="itemVenda"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<dynamic>> Create([FromBody] Models.ItemVenda itemVenda)  // Deixei o nome produto em portugês para facilitar o entendimento do código quanto a diferenciação do modelo utilizado no Controller(em portugues) e o modelo utilizado pela camada de dados(em inglês)
        {
            try
            {
                // O método extendido ToModel vem do Factory de converter que está em StockService.Controllers.Converters
                var operationResult = await this._productService.UpdateStockAsync
                    (this._converterFactory.GeToModelConverter<SaleService.Models.SaleItem, Models.ItemVenda>().ToModel(itemVenda));
                if (!operationResult.Success)
                {
                    return StatusCode(400, operationResult.ErrorMessage);
                }
                return Ok(new { });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
