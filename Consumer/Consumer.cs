using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Services.Models;
using Services.Services;
using System.Text;
using System.Text.Json;

namespace Consumer;

public class Consumer
{
    private readonly IModel _channel;

    public Consumer(RabbitMQService rabbitMQService, string queueName)
    {
        _channel = rabbitMQService.CreateModel();

        //_channel.QueueDeclare(queueName, exclusive: false);

        var consumer = new EventingBasicConsumer(_channel);

        consumer.Received += (model, receivedEventArgs) =>
        {
            var body = receivedEventArgs.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($"Log message received : {message}");

            //var logMessage = JsonSerializer.Deserialize<LogModel>(message);
            //veritabanına ekle
            //dosyaya kaydet

        };

        _channel.BasicConsume(queue: queueName, autoAck: true //true ise mesaj otomatik olarak kuyruktan silinir
            , consumer: consumer);

        Console.WriteLine($"{queueName} listening.....\n\n\n");

    }

}
