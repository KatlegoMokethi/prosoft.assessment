using System.Text;
using Asp.Versioning;
using FeedbackSystem.API.Configuration;
using FeedbackSystem.API.Filters;
using FeedbackSystem.API.Middleware;
using FeedbackSystem.Application;
using FeedbackSystem.Infrastructure;
using FeedbackSystem.Persistence.Postgres;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

ConfigureJWTBearerAuthentication(builder);
ConfigureSwagger(builder.Services);
ConfigureApiVersioning(builder.Services);

builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceLayer(builder.Configuration.GetConnectionString("DbConnectionString")!);
builder.Services.AddNotificationService(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseMiddleware<ApiKeyMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

void ConfigureJWTBearerAuthentication(WebApplicationBuilder builder)
{
    var authOptions = new AuthenticationOptions();
    builder.Configuration.GetSection("AuthenticationOptions").Bind(authOptions);
    builder.Services.AddSingleton(authOptions);

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = authOptions.Issuer,
                ValidAudience = authOptions.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOptions.SecurityKey))
            };
        });
}

void ConfigureSwagger(IServiceCollection services)
{
    services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Customer Feedback Management System",
            Description = "Prosoft Customer Feedback Management System API",
            TermsOfService = new Uri("https://prosoftit.wpengine.com/terms-of-use/"),
            Contact = new OpenApiContact
            {
                Name = "Contact",
                Url = new Uri("https://prosoft.dev/contact/")
            }
        });

        options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
        {
            Description = "API Key needed to access the endpoints. ApiKey: ****",
            In = ParameterLocation.Header,
            Name = "ApiKey",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "ApiKeyScheme"
        });

        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer"
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "ApiKey"
                    },
                    Scheme = "ApiKeyScheme",
                    Name = "ApiKey",
                    In = ParameterLocation.Header,

                },
                new List<string>()
            },
            {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "Bearer",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                    },
                    new List<string>()
                }
        });

        options.OperationFilter<RemoveVersionParameterFilter>();
        options.DocumentFilter<RemoveVersionWithValueFilter>();

    });
}

void ConfigureApiVersioning(IServiceCollection services)
{
    services.AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(1);
        options.ReportApiVersions = true;
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ApiVersionReader = new UrlSegmentApiVersionReader();
    }).AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'V";
        options.SubstituteApiVersionInUrl = true;
    });
}
