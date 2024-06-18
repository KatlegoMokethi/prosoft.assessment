namespace FeedbackSystem.API.Middleware;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private const string ApiKeyHeaderName = "ApiKey";

    public ApiKeyMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var headerApiKeyValue))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Api Key is not specified.");
            return;
        }

        var config = context.RequestServices.GetRequiredService<IConfiguration>();
        var apiKey = config.GetValue<string>(ApiKeyHeaderName);

        if (!string.IsNullOrEmpty(apiKey) && !apiKey.Equals(headerApiKeyValue))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized request.");
            return;
        }

        await _next(context);
    }
}

