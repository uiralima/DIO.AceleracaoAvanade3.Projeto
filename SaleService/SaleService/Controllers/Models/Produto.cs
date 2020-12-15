using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleService.Controllers.Models
{
    /// <summary>
    /// Modelo de controller produto
    /// </summary>
    public class Produto : IControllerModel // Deixei o nome em protugês mesmo fugindo do padrão para facilitar a diferenciação do modelo de dados Product
    {
        public string Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public decimal QuantidadeEmEstoque { get; set; }
    }
}
