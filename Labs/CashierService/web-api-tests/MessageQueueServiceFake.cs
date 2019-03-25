using System;
using System.Collections.Generic;
using System.Linq;
using CashierServices.Contracts;
using CashierServices.Models;

namespace CashierServicesTests
{
    class MessageQueueServiceFake : IMessageQueueService
    {
        public void SendMessage(string message)
        {

        }
    }
}