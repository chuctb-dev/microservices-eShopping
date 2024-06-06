using eShopping.SharedKernel.Events;

namespace eShopping.MassTransit.Services
{
    public interface IMassTransitHandler
    {
        Task Publish(IIntegrationEvents @event, Type type);

        Task Send(string queueName, IIntegrationEvents @event, Type type);
    }
}