using eShopping.SharedKernel.Events;
using MassTransit;

namespace eShopping.MassTransit.Services
{
    public class MassTransitHandler(IPublishEndpoint publishEndpoint, ISendEndpointProvider sendEndpointProvider) : IMassTransitHandler
    {
        public async Task Publish(IIntegrationEvents @event, Type type)
        {
            await publishEndpoint.Publish(@event, type);
        }

        public async Task Send(string queueName, IIntegrationEvents @event, Type type)
        {
            var sendEndpoint = await sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{queueName}"));

            await sendEndpoint.Send(@event, type);
        }
    }
}