using RabbitMQ.Client;
using Services.Models;
using Services.Services;
using System.Text;
using System.Text.Json;

namespace Producer;

public class MessagePublisher
{
    private readonly IModel _channel;

    public MessagePublisher(RabbitMQService rabbitMQService, string exchangeName, string routingKey)
    {
        _channel = rabbitMQService.CreateModel();

        _channel.ExchangeDeclare(exchange: exchangeName, type: ExchangeType.Direct);
        _channel.QueueDeclare(queue: routingKey, durable: false, exclusive: false, autoDelete: false, arguments: null);
        _channel.QueueBind(queue: routingKey, exchange: exchangeName, routingKey: routingKey);
    }

    public void PublishMessage()
    {
        var message = new LogModel() { LogType = "Info", LogMessage = "Hello RabbitMQ" };

        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

        _channel.BasicPublish(exchange: "LogExchange", routingKey: "LogQueue", basicProperties: null, body: body);
    }
}
