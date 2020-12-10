using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using StockService.Controllers.Converters;

namespace StockService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Services.Abstracts.IProductService _productService;
        public ProductController(Services.Abstracts.IProductService productService)
        {
            this._productService = productService;
        }
        [HttpGet]
        public IEnumerable<Models.Produto> Get()
        {
            // O método extendido FromModel vem do Factory de converter que está em StockService.Controllers.Converters
            return this._productService.Get().Select(f => (Models.Produto)f.FromModel());
        }
        [HttpPost]
        public void Create([FromBody] Models.Produto produto)  // Deixei o nome produto em portugês para facilitar o entendimento do código quanto a diferenciação do modelo utilizado no Controller(em portugues) e o modelo utilizado pela camada de dados(em inglês)
        {
            // O método extendido ToModel vem do Factory de converter que está em StockService.Controllers.Converters
            this._productService.Create((StockService.Models.Product)produto.ToModel());
        }
        [HttpPut]
        public void Update([FromQuery] int id, [FromBody] Models.Produto produto) // Deixei o nome produto em portugês para facilitar o entendimento do código quanto a diferenciação do modelo utilizado no Controller(em portugues) e o modelo utilizado pela camada de dados(em inglês)
        {
            produto.ID = id;
            // O método extendido ToModel vem do Factory de converter que está em StockService.Controllers.Converters
            this._productService.Update((StockService.Models.Product)produto.ToModel());
        }
    }
}
