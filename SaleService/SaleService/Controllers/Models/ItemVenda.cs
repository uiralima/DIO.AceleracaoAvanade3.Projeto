using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleService.Controllers.Models
{
    /// <summary>
    /// Modelo de controler Item de Venda
    /// </summary>
    public class ItemVenda : IControllerModel // Deixei o nome em protugês mesmo fugindo do padrão para facilitar a diferenciação do modelo de dados Product
    {
        /// <summary>
        /// Id do Produto
        /// </summary>
        public string IdProduto { get; set; }
        /// <summary>
        /// Quantdade vndida
        /// </summary>
        public decimal QuantidadeVedida { get; set; }
    }
}
