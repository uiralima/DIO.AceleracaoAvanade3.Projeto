using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockService.Controllers.Models
{
    public class Produto : IControllerModel
    {
        public string Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public decimal QuantidadeEmEstoque { get; set; }
    }
}
