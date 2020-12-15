using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SaleService.Services.Implementations
{
    /// <summary>
    /// Implemeta a assinatura de recebimento de notificações do Azure
    /// </summary>
    public class AzureServiceBusNotifiedService : Abstracts.INotifiedService
    {
        private const string CONN_STRING = "";
        private const string SUBSCRIPTION_NAME = "SaleService";
        private const string CREATE_PRODUCT_NOTIFICATION_KEY = "produtocriado";
        private const string UPDTE_PRODUCT_NOTIFICATION_KEY = "produtoatualizado";

        private Abstracts.IProductService _productService;
        private SubscriptionClient _createdProductBusClient = new SubscriptionClient(CONN_STRING, CREATE_PRODUCT_NOTIFICATION_KEY, SUBSCRIPTION_NAME);
        private SubscriptionClient _updatedProductBusClient = new SubscriptionClient(CONN_STRING, UPDTE_PRODUCT_NOTIFICATION_KEY, SUBSCRIPTION_NAME);

        Abstracts.Converter.IModelByteConverter _converter;
        public AzureServiceBusNotifiedService(Abstracts.IProductService productService, Abstracts.Converter.IModelByteConverter converter)
        {
            this._productService = productService;
            this._converter = converter;

        }

        private async Task ProcessCreateProductMessageAsync(Message message, CancellationToken arg2)
        {
            var item = this._converter.FromBytes<Models.Product>(message.Body);
            await this._productService.CreateAsync(item);
        }

        private async Task ProcessUpdateProductMessageAsync(Message message, CancellationToken arg2)
        {
            var item = this._converter.FromBytes<Models.Product>(message.Body);
            await this._productService.UpdateAsync(item);
        }

        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs arg)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Assinatura das notificações
        /// </summary>
        public void StartListen()
        {
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            this._createdProductBusClient.RegisterMessageHandler(ProcessCreateProductMessageAsync, messageHandlerOptions);
            this._updatedProductBusClient.RegisterMessageHandler(ProcessUpdateProductMessageAsync, messageHandlerOptions);
        }
    }
}
