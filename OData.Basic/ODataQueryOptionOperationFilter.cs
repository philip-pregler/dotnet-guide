using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace OData.Basic
{
    public class ODataQueryOptionOperationFilter : IOperationFilter
    {
        private Dictionary<string, (string Description, string Type)> odataQueryOptionDescriptions = new()
        {
            ["$filter"] = ("An OData $filter expression to filter the list of tasks based on specified criteria. The expression must be a valid OData expression using logical and/or operators and can include nested expressions.", "string"),
            ["$expand"] = ("An OData $expand expression to include related entities in the response. The expression must be a valid OData expression specifying the related entities to include in the response.", "string"),
            ["$select"] = ("An OData $select expression to select specific properties from the list of tasks. The expression must be a valid OData expression specifying the properties to include in the response.", "string"),
            ["$orderby"] = ("An OData $orderby expression to sort the list of tasks. The expression must be a valid OData expression specifying the property or properties to use for sorting and the sort order (ascending or descending).", "string"),
            ["$top"] = ("An OData $top expression to limit the number of tasks returned in the response. The expression must be a valid OData expression specifying the maximum number of tasks to return.", "integer"),
            ["$skip"] = ("An OData $skip expression to specify the number of tasks to skip in the response. The expression must be a valid OData expression specifying the number of tasks to skip.", "integer"),
            ["$search"] = ("An OData $search expression to filter the list of tasks based on search terms. The expression must be a valid OData expression using the search operator and can include logical and/or operators and nested expressions.", "string"),
            ["$compute"] = ("An OData $compute expression to include additional computed fields in the response. The expression must be a valid OData expression specifying the computed fields to include in the response.", "string"),
            ["$count"] = ("An OData $count expression to include the number of tasks in the response. The expression must be a valid OData expression specifying that the count should be included in the response.", "boolean")
        };
        
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.ApiDescription.RelativePath?.StartsWith("odata") != true || context.ApiDescription.RelativePath is "odata/$metadata" or "odata")
            {
                return;
            }

            foreach (var property in odataQueryOptionDescriptions)
            {
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = property.Key,
                    In = ParameterLocation.Query,
                    Description = property.Value.Description,
                    Required = false,
                    Schema = new OpenApiSchema
                    {
                        Type = property.Value.Type
                    }
                });
            }
        }
    }
}
