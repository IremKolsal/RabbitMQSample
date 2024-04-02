using RabbitMQ.Client;

namespace Services.Services;

public class RabbitMQService
{

    private readonly IConnection _connection;

    public RabbitMQService()
    {
        var connectionFactory = new ConnectionFactory()
        {
            HostName = "localhost",
            UserName = "guest",
            Password = "guest"
        };

        _connection = connectionFactory.CreateConnection();
    }

    public IModel CreateModel()
    {
        return _connection.CreateModel();
    }
}
