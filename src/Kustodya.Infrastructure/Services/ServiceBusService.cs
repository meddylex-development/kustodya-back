using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.Infrastructure.Services
{
    public class ServiceBusService : IServiceBus
    {
        private readonly IServiceBusPersisterConnection _serviceBusPersisterConnection;
        private readonly ILogger<ServiceBusService> _logger;

        public ServiceBusService(IServiceBusPersisterConnection serviceBusPersisterConnection,
            ILogger<ServiceBusService> logger)
        {
            _logger = logger;
            _serviceBusPersisterConnection = serviceBusPersisterConnection;
        }

        public void Publish(object @object)
        {
            var jsonMessage = JsonConvert.SerializeObject(@object);
            var body = Encoding.UTF8.GetBytes(jsonMessage);

            var message = new Message
            {
                MessageId = Guid.NewGuid().ToString(),
                Body = body
            };

            var topicClient = _serviceBusPersisterConnection.CreateModel();

            topicClient.SendAsync(message)
                .GetAwaiter()
                .GetResult();
        }
    }
}
