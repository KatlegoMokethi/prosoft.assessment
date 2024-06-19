namespace FeedbackSystem.Infrastructure.Configuration;

public class MailNotificationOptions
{
    public string FromAddress { get; set; } = string.Empty;
    public List<string> AdminEmails { get; set; } = new();
    public string DisplayName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Host { get; set; } = string.Empty;
    public int Port { get; set; } = default;
}

