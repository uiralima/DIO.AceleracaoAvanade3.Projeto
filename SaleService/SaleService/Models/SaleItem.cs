namespace SaleService.Models
{
    /// <summary>
    /// Model de dados do Item vendido
    /// </summary>
    public class SaleItem : IModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get ; set ; }
        /// <summary>
        /// Id do produto
        /// </summary>
        public string ProductId { get; set; }
        /// <summary>
        /// Quantidade vendida
        /// </summary>
        public decimal Amount { get; set; }
    }
}
