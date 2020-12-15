using System;

namespace SaleService.Models
{
    /// <summary>
    /// Classe que contém as informações de retorno padrão do serviço
    /// </summary>
    public class OperationResult
    {
        /// <summary>
        /// Construto padrao para operações realizadas com sucesso.
        /// </summary>
        public OperationResult()
        {
            this.Success = true;
            this.ErrorMessage = String.Empty;
        }

        /// <summary>
        /// Construtor padrão para operações não realizadas corretamente
        /// </summary>
        /// <param name="errorMessage"></param>
        public OperationResult(string errorMessage)
        {
            this.Success = false;
            this.ErrorMessage = errorMessage;
        }
        /// <summary>
        /// Indica o scesso da operação
        /// </summary>
        public bool Success { get; private set; }
        /// <summary>
        /// Mensagem de erro decorrente da operação
        /// </summary>
        public string ErrorMessage { get; private set; }
    }
}
