using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StockService.Services.Implementations
{
    public class AzureServiceBusNotifiedService: Abstracts.INotifiedService
    {
        private const string CONN_STRING = "";
        private const string SUBSCRIPTION_NAME = "StockService";
        private const string SOLD_NOTIFICATION_KEY = "produtovendido";

        private Abstracts.IProductService _productService;
        private SubscriptionClient _createdProductBusClient = new SubscriptionClient(CONN_STRING, SOLD_NOTIFICATION_KEY, SUBSCRIPTION_NAME);

        Abstracts.Converter.IModelByteConverter _converter;
        public AzureServiceBusNotifiedService(Abstracts.IProductService productService, Abstracts.Converter.IModelByteConverter converter)
        {
            this._productService = productService;
            this._converter = converter;
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            this._createdProductBusClient.RegisterMessageHandler(ProcessCreateproductMessageAsync, messageHandlerOptions);
        }

        private Task ProcessCreateproductMessageAsync(Message message, CancellationToken arg2)
        {
            var newProduct = this._converter.FromBytes<Models.Product>(message.Body);
            this._productService.Create(newProduct);
            return Task.CompletedTask;
        }

        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs arg)
        {
            throw new NotImplementedException();
        }
    }
}
