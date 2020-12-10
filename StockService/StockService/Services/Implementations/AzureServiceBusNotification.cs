using Microsoft.Azure.ServiceBus;
using StockService.Utils;
using System;

namespace StockService.Services.Implementations
{
    public class AzureServiceBusNotification : Abstracts.INotifyService
    {
        private const string CONN_STRING = "";
        public void Send(string niotificationTitle, Models.IModel notificationData)
        {
            var serviceBusClient = new TopicClient(CONN_STRING, niotificationTitle);

            var message = new Message(notificationData.ToJsonBytes());
            message.ContentType = "application/json";
            message.UserProperties.Add("CorrelationId", Guid.NewGuid().ToString());
            serviceBusClient.SendAsync(message);
        }
    }
}
