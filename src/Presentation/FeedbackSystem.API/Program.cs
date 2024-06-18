using Asp.Versioning;
using FeedbackSystem.API.Filters;
using FeedbackSystem.Application;
using FeedbackSystem.Persistence.Postgres;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

ConfigureSwagger(builder.Services);
ConfigureApiVersioning(builder.Services);

builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceLayer(builder.Configuration.GetConnectionString("DbConnectionString")!);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();
app.Run();

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
