using Microsoft.Azure.ServiceBus;
using SaleService.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SaleService.Services.Implementations
{
    public class AzureNorificatinService : Abstracts.INotifiedService
    {
        private const string CONN_STRING = "";
        private const string SUBSCRIPTION_NAME = "SaleService";
        private const string CREATE_NOTIFICATION_KEY = "produtocriado";
        private const string UPDATE_NOTIFICATION_KEY = "produtoatualizado";

        private Abstracts.IProductService _productService;
        private SubscriptionClient _createdProductBusClient = new SubscriptionClient(CONN_STRING, CREATE_NOTIFICATION_KEY, SUBSCRIPTION_NAME);
        public AzureNorificatinService(Abstracts.IProductService productService)
        {
            this._productService = productService;
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            this._createdProductBusClient.RegisterMessageHandler(ProcessCreateproductMessageAsync, messageHandlerOptions);
        }

        private Task ProcessCreateproductMessageAsync(Message message, CancellationToken arg2)
        {
            var newProduct = message.Body.ParseJson<Models.Product>();
            this._productService.Create(newProduct);
            return Task.CompletedTask;
        }

        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs arg)
        {
            throw new NotImplementedException();
        }
    }
}
