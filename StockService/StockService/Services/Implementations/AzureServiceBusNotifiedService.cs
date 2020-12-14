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
        class SaleItem
        {
            public string ProductId { get; set; }
            public decimal Amount { get; set; }
        }

        class Sale
        {
            public SaleItem[] Items { get; set; }
        }

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
            
        }

        private async Task ProcessSaleProductsMessageAsync(Message message, CancellationToken arg2)
        {
            var newSale = this._converter.FromBytes<Sale>(message.Body);
            foreach (var item in newSale.Items)
            {
                await this._productService.UpdateStockAsync(item.ProductId, item.Amount);
            }
        }

        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs arg)
        {
            throw new NotImplementedException();
        }

        public void StartListen()
        {
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            this._createdProductBusClient.RegisterMessageHandler(ProcessSaleProductsMessageAsync, messageHandlerOptions);
        }
    }
}
