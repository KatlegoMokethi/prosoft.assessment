using System.Net;
using System.Net.Mail;
using FeedbackSystem.Infrastructure.Configuration;
using FeedbackSystem.Infrastructure.Models;

namespace FeedbackSystem.Infrastructure.Services;

public class NotificationService : INotificationService
{
    readonly MailNotificationOptions _notificationOptions;

    public NotificationService(MailNotificationOptions notificationOptions)
    {
        _notificationOptions = notificationOptions;
    }

    public async Task SendEmailAsync(MailOptions mailOptions)
    {
        var message = new MailMessage();
        var smtp = new SmtpClient();

        message.From = new MailAddress(_notificationOptions.FromAddress, _notificationOptions.DisplayName);
        message.To.Add(string.Join(",", _notificationOptions.AdminEmails));
        message.Subject = mailOptions.Subject;

        message.IsBodyHtml = false;
        message.Body = mailOptions.Body;

        smtp.Port = _notificationOptions.Port;
        smtp.Host = _notificationOptions.Host;
        smtp.EnableSsl = true;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new NetworkCredential(_notificationOptions.FromAddress, _notificationOptions.Password);
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        await smtp.SendMailAsync(message);
    }
}
