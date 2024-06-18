using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FeedbackSystem.API.Filters;

public class RemoveVersionParameterFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var vParam = operation.Parameters.SingleOrDefault(x => x.Name == "v");
        operation.Parameters.Remove(vParam);
    }
}

