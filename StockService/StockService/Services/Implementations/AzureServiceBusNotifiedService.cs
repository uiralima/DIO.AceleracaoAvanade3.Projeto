using Microsoft.Azure.ServiceBus;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StockService.Services.Implementations
{
    /// <summary>
    /// Implemeta a assinatura de recebimento de notificações do Azure
    /// </summary>
    public class AzureServiceBusNotifiedService: Abstracts.INotifiedService
    {
        /// <summary>
        /// Dados recebidos pelas notificações
        /// </summary>
        class SaleItem
        {
            public string Id { get; set; }
            public string ProductId { get; set; }
            public decimal Amount { get; set; }
        }

        /// <summary>
        /// String de conexão
        /// </summary>
        private const string CONN_STRING = "";
        private const string SUBSCRIPTION_NAME = "StockService";
        private const string SOLD_NOTIFICATION_KEY = "produtovendido";

        private Abstracts.IProductService _productService;
        private SubscriptionClient _soldProductBusClient = new SubscriptionClient(CONN_STRING, SOLD_NOTIFICATION_KEY, SUBSCRIPTION_NAME);

        Abstracts.Converter.IModelByteConverter _converter;
        public AzureServiceBusNotifiedService(Abstracts.IProductService productService, Abstracts.Converter.IModelByteConverter converter)
        {
            this._productService = productService;
            this._converter = converter;
            
        }

        private async Task ProcessSoldProductMessageAsync(Message message, CancellationToken arg2)
        {
            var item = this._converter.FromBytes<SaleItem>(message.Body);
            await this._productService.UpdateStockAsync(item.ProductId, item.Amount);
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

            this._soldProductBusClient.RegisterMessageHandler(ProcessSoldProductMessageAsync, messageHandlerOptions);
        }
    }
}
