using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleService.Controllers.Models
{
    public class Venda : IControllerModel
    {
        public ItemVenda[] Itens { get; set; }
    }
}
