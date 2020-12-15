using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockService.Models
{
    /// <summary>
    /// Contrato para model de dados do serviço
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// Id obrigatório para dados persistidos.
        /// </summary>
        public string Id { get; set; }
    }
}
