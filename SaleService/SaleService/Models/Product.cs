using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleService.Models
{
    public class Product : IModel
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Stock { get; set; }
    }
}
