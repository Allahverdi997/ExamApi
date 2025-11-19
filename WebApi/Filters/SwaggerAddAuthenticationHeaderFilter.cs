using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApi.Filters
{
    public class SwaggerAddAuthenticationHeaderFilter : IOperationFilter
    {
        void IOperationFilter.Apply(OpenApiOperation operation, OperationFilterContext context)
        {

            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();


            AddDefaultParameter(operation);


        }

        private void AddDefaultParameter(OpenApiOperation operation)
        {
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "AuthenticationToken",
                In = ParameterLocation.Header,
                Description = "",
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Default = new OpenApiString("")
                }
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Language",
                In = ParameterLocation.Header,
                Description = "",
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Default = new OpenApiString("")
                }
            });
        }
    }
}
