namespace StockService.Services.Abstracts
{
    /// <summary>
    /// Contrato para serviços que irão ser notificados pelo pipe
    /// </summary>
    public interface INotifiedService
    {
        /// <summary>
        /// Habilita as notificações
        /// </summary>
        void StartListen();
    }
}
