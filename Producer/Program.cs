namespace Producer;

public class Program
{
    public static void Main()
    {
        var rabbitMQService = new Services.Services.RabbitMQService();

        //mesaj gönderen servis
        var messagePublisher = new MessagePublisher(rabbitMQService, "LogExchange", "LogQueue");
        messagePublisher.PublishMessage();

    }
}
