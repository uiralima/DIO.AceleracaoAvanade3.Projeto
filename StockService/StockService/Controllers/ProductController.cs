﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using StockService.Controllers.Converters;
using System.Threading.Tasks;

namespace StockService.Controllers
{
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
        [HttpGet]
        public ActionResult<IEnumerable<Models.Produto>> GetAll()
        {
            try
            {
                // O método extendido FromModel vem do Factory de converter que está em StockService.Controllers.Converters
                return Ok(this._productService.GetAll().Select(f => this._converterFactory.GetConverter<StockService.Models.Product, Models.Produto>().FromModel(f)));
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<dynamic> Create([FromBody] Models.Produto produto)  // Deixei o nome produto em portugês para facilitar o entendimento do código quanto a diferenciação do modelo utilizado no Controller(em portugues) e o modelo utilizado pela camada de dados(em inglês)
        {
            try
            {
                // O método extendido ToModel vem do Factory de converter que está em StockService.Controllers.Converters
                var operationResult = this._productService
                    .Create(this._converterFactory.GetConverter<StockService.Models.Product, Models.Produto>().ToModel(produto));
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
        [HttpPut]
        public ActionResult<dynamic> Update([FromQuery] int id, [FromBody] Models.Produto produto) // Deixei o nome produto em portugês para facilitar o entendimento do código quanto a diferenciação do modelo utilizado no Controller(em portugues) e o modelo utilizado pela camada de dados(em inglês)
        {
            try
            {
                produto.ID = id;
                // O método extendido ToModel vem do Factory de converter que está em StockService.Controllers.Converters
                var operationResult = this._productService
                    .Update(this._converterFactory.GetConverter<StockService.Models.Product, Models.Produto>().ToModel(produto));
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
