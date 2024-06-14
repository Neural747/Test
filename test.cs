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
