using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockService.Models
{
    public class OperationResult
    {
        public OperationResult()
        {
            this.Success = true;
            this.ErrorMessage = String.Empty;
        }

        public OperationResult(string errorMessage)
        {
            this.Success = false;
            this.ErrorMessage = errorMessage;
        }
        public bool Success { get; private set;  }
        public string ErrorMessage { get; private set; }
    }
}
