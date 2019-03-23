using CashierServices.Models;

namespace CashierServices.Contracts
{
    public interface IMessageQueueService
    {
        void SendMessage(string message);

    }
}