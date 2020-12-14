using Microsoft.Azure.ServiceBus;
using System;
using System.Threading.Tasks;

namespace StockService.Services.Implementations
{
    public class AzureServiceBusNotifyService : Abstracts.INotifyService
    {
        private const string CONN_STRING = "";
        private readonly Abstracts.Converter.IModelByteConverter _converter;
        public AzureServiceBusNotifyService(Abstracts.Converter.IModelByteConverter converter)
        {
            this._converter = converter;
        }
        public async Task Send(string niotificationTitle, Models.IModel notificationData)
        {
            var serviceBusClient = new TopicClient(CONN_STRING, niotificationTitle);
            var message = new Message(this._converter.ToBytes(notificationData));
            message.ContentType = this._converter.CotentType;
            await serviceBusClient.SendAsync(message);
        }

        
    }
}
