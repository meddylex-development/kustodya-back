namespace Kustodya.Infrastructure.Services
{
    public interface IServiceBus
    {
        void Publish(object @object);
    }
}