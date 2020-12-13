using Microsoft.Azure.ServiceBus;
using System;

namespace StockService.Services.Implementations
{
    public class AzureServiceBusNotification : Abstracts.INotifyService, Abstracts.INotifiedService 
    {
        private const string CONN_STRING = "";
        private readonly Abstracts.Converter.IModelByteConverter _converter;
        public AzureServiceBusNotification(Abstracts.Converter.IModelByteConverter converter)
        {
            this._converter = converter;
        }
        public async void Send(string niotificationTitle, Models.IModel notificationData)
        {
            var serviceBusClient = new TopicClient(CONN_STRING, niotificationTitle);
            var message = new Message(this._converter.ToBytes(notificationData));
            message.ContentType = this._converter.CotentType;
            await serviceBusClient.SendAsync(message);
        }
    }
}
