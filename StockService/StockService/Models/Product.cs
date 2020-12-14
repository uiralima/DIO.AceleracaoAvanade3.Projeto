namespace StockService.Models
{
    public class Product : IModel
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Stock { get; set; }
    }
}
