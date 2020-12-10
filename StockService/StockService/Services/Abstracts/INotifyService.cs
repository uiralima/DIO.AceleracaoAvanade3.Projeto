using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockService.Services.Abstracts
{
    public interface INotifyService
    {
        public void Send(string niotificationTitle, Models.IModel notificationData);
    }
}
