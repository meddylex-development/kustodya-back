using Microsoft.Azure.ServiceBus;

namespace Kustodya.Infrastructure.Services
{
    public interface IServiceBusPersisterConnection
    {
        ServiceBusConnectionStringBuilder ServiceBusConnectionStringBuilder { get; }

        ITopicClient CreateModel();
        void Dispose();
    }
}