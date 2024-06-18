namespace FeedbackSystem.API.Configuration;

public class AuthenticationOptions
{
    public string UserId { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public string SecurityKey { get; set; } = string.Empty;
    public int ExpiryTimeInMinutes { get; set; }
}
