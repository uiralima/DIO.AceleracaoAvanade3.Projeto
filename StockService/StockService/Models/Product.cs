namespace StockService.Models
{
    /// <summary>
    /// Model de dados do produto
    /// </summary>
    public class Product : IModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Código
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Nome
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Preço
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Estoque disponível
        /// </summary>
        public decimal Stock { get; set; }
    }
}
