using Microsoft.Azure.ServiceBus;
using SaleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleService.Services.Implementations
{
    /// <summary>
    /// Implementa o envio de notificações ao Azure
    /// </summary>
    public class AzureServiceBusNotifyService : Abstracts.INotifyService
    {
        private const string CONN_STRING = "";
        private readonly Abstracts.Converter.IModelByteConverter _converter;
        public AzureServiceBusNotifyService(Abstracts.Converter.IModelByteConverter converter)
        {
            this._converter = converter;
        }

        /// <summary>
        /// Envia uma notificação
        /// </summary>
        /// <param name="niotificationTitle"></param>
        /// <param name="notificationData"></param>
        /// <returns></returns>
        public async Task Send(string niotificationTitle, Models.IModel notificationData)
        {
            var serviceBusClient = new TopicClient(CONN_STRING, niotificationTitle);
            var message = new Message(this._converter.ToBytes(notificationData));
            message.ContentType = this._converter.CotentType;
            await serviceBusClient.SendAsync(message);
        }
    }
}
