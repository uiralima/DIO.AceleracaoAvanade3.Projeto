using System.Threading.Tasks;

namespace StockService.Services.Abstracts
{
    /// <summary>
    /// Contrato para serviços que enviarão notificação para o pipe
    /// </summary>
    public interface INotifyService
    {
        /// <summary>
        /// Envia uma notificação para o pipe
        /// </summary>
        /// <param name="niotificationTitle">tag do Tópico</param>
        /// <param name="notificationData">Dado eviado na mnsagem</param>
        /// <returns></returns>
        public Task Send(string niotificationTitle, Models.IModel notificationData);
    }
}
