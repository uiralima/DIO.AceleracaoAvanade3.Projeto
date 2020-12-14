using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleService.Controllers.Models
{
    public class ItemVenda : IControllerModel
    {
        public string IdProduto { get; set; }
        public decimal Quantidade { get; set; }
    }
}
