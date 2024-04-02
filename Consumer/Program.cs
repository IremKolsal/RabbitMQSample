namespace Consumer;

public class Program
{
    public static void Main()
    {
        var rabbitMQService = new Services.Services.RabbitMQService();

        //mesaj alan servis
        new Consumer(rabbitMQService, "LogQueue");

        Console.WriteLine("Uygulama başarıyla çalıştı. Çıkış yapmak için bir tuşa basın");
        Console.ReadLine();

    }
}
