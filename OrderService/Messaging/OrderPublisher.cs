using MassTransit;
using OrderService.Models;
//using System.Text.Json;
//using Azure.Messaging.ServiceBus;

namespace OrderService.Messaging
{
    public class OrderPublisher
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public OrderPublisher(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task PublishOrderAsync(Order order)
        {
            await _publishEndpoint.Publish(order);
        }
    }

    //public class OrderPublisher
    //{
    //    private readonly ServiceBusClient _client;
    //    private readonly ServiceBusSender _sender;

    //    public OrderPublisher(ServiceBusClient client, string qName)
    //    {
    //        _client = client;
    //        _sender = _client.CreateSender(qName);
    //    }

    //    public async Task PublishOrderAsync(Order order)
    //    {
    //        var orderJson = JsonSerializer.Serialize(order);
    //        var message = new ServiceBusMessage(orderJson);
    //        await _sender.SendMessageAsync(message);
    //    }
    //}
}
