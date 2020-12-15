namespace SaleService.Models
{
    /// <summary>
    /// Contrato para o modelo de dados de dados que tem id
    /// </summary>
    public interface IIdModel : IModel
    {
        public string Id { get; set; }
    }
}
