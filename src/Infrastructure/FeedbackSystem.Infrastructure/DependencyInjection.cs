using FeedbackSystem.Infrastructure.Configuration;
using FeedbackSystem.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace FeedbackSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddNotificationService(this IServiceCollection services, IConfiguration config)
    {
        var notificationOptions = new MailNotificationOptions();
        config.GetSection("MailNotificationOptions").Bind(notificationOptions);
        services.AddSingleton(notificationOptions);

        services.AddSingleton<INotificationService, NotificationService>();

        return services;
    }
}
