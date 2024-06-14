using Microsoft.Extensions.DependencyInjection;
using System;

class Program
{
    static void Main(string[] args)
    {
        // Set up DI container
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IMessageService, SmsService>()
            .AddSingleton<IEmailService, EmailService>()
            .AddSingleton<NotificationService>()
            .BuildServiceProvider();

        // Resolve and use the NotificationService
        var notificationService = serviceProvider.GetService<NotificationService>();
        notificationService.Notify("Hello, this is a test message!", "test@example.com");
    }
}

public class NotificationService
{
    private readonly IMessageService _messageService;
    private readonly IEmailService _emailService;

    public NotificationService(IMessageService messageService, IEmailService emailService)
    {
        _messageService = messageService;
        _emailService = emailService;
    }

    public void Notify(string message, string email)
    {
        _messageService.SendMessage(message);
        _emailService.SendEmail(email);
    }
}

public class SmsService : IMessageService
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Sending SMS: {message}");
    }
}

public class EmailService : IEmailService
{
    public void SendEmail(string email)
    {
        Console.WriteLine($"Sending Email: {email}");
    }
}


