using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FeedbackSystem.API.Filters;

public class RemoveVersionWithValueFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var paths = new OpenApiPaths();

        foreach (var path in swaggerDoc.Paths)
            paths.Add(path.Key.Replace("v{v}", swaggerDoc.Info.Version), path.Value);

        swaggerDoc.Paths = paths;
    }
}

