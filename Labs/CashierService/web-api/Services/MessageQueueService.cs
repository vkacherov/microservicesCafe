using CashierServices.Contracts;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Options;
using System.Text;

namespace CashierServices.Services
{
    public class MessageQueueService : IMessageQueueService
    {
        private readonly QueueClient _queueClient;
        
        public MessageQueueService (IOptions<ApplicationSettings> settings)
        {
            _queueClient = 
                new QueueClient(
                    settings.Value.ServiceBusConnection,
                    settings.Value.QueueName);
        }
        public void SendMessage(string  message)
        {
            Message msg = new Message(Encoding.UTF8.GetBytes(message));
            
            _queueClient.SendAsync(msg);
        }

    }
}
