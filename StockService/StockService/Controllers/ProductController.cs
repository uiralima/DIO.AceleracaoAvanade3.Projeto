using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using StockService.Controllers.Converters;
using System.Threading.Tasks;

namespace StockService.Controllers
{
    /// <summary>
    /// Controlador de requisições de produtos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Services.Abstracts.IProductService _productService;
        private readonly Converters.Abstracts.IFactory _converterFactory;
        public ProductController(Services.Abstracts.IProductService productService, Converters.Abstracts.IFactory converterFactory)
        {
            this._converterFactory = converterFactory;
            this._productService = productService;
        }

        /// <summary>
        /// Recupera todos 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Produto>>> GetAll()
        {
            try
            {
                return Ok((await this._productService.GetAllAsync()).Select(f => this._converterFactory.GetConverter<StockService.Models.Product, Models.Produto>().FromModel(f)));
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Insere um novo produto
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<dynamic>> Create([FromBody] Models.Produto produto)  // Deixei o nome produto em portugês para facilitar o entendimento do código quanto a diferenciação do modelo utilizado no Controller(em portugues) e o modelo utilizado pela camada de dados(em inglês)
        {
            try
            {
                var operationResult = await this._productService
                    .CreateAsync(this._converterFactory.GetConverter<StockService.Models.Product, Models.Produto>().ToModel(produto));
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

        /// <summary>
        /// Atualiza o produto  
        /// </summary>
        /// <param name="id"></param>
        /// <param name="produto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<dynamic>> Update(string id, [FromBody] Models.Produto produto) // Deixei o nome produto em portugês para facilitar o entendimento do código quanto a diferenciação do modelo utilizado no Controller(em portugues) e o modelo utilizado pela camada de dados(em inglês)
        {
            try
            {
                produto.Id = id;
                var operationResult = await this._productService
                    .UpdateAsync(this._converterFactory.GetConverter<StockService.Models.Product, Models.Produto>().ToModel(produto));
                if (!operationResult.Success)
                {
                    return StatusCode(400, operationResult.ErrorMessage);
                }
                return Ok(new { });
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
