using CashierServices.Contracts;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Microsoft.Azure.ServiceBus.Primitives;
using Microsoft.Extensions.Options;
using System.Text;

namespace CashierServices.Services
{
    public class MessageQueueService : IMessageQueueService
    {
        private readonly QueueClient _queueClient;
        
        public MessageQueueService (IOptions<ApplicationSettings> settings)
        {
            var builder = new ServiceBusConnectionStringBuilder(settings.Value.ServiceBusConnection);

            var tokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(
                builder.SasKeyName,
                builder.SasKey);

            _queueClient = 
                new QueueClient(
                    builder.Endpoint,
                    settings.Value.QueueName, tokenProvider, TransportType.AmqpWebSockets);
        }
        public void SendMessage(string  message)
        {
            Message msg = new Message(Encoding.UTF8.GetBytes(message));
            
            _queueClient.SendAsync(msg);
        }

    }
}
