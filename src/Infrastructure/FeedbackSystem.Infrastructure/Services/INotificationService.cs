using FeedbackSystem.Infrastructure.Models;

namespace FeedbackSystem.Infrastructure.Services;

public interface INotificationService
{
    Task SendEmailAsync(MailOptions mailRequest);
}
