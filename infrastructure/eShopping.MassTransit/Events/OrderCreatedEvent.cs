using eShopping.SharedKernel.Events;

namespace eShopping.MassTransit.Events
{
    public class OrderCreatedEvent : IIntegrationEvents
    {
        public string Username { get; set; }
        public bool IsSuccess { get; set; }
    }
}