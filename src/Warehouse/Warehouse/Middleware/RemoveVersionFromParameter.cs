using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Middleware
{
    public class RemoveVersionFromParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var versionParameters = operation.Parameters.Where(p => p.Name == "version").ToList();
            foreach (var parameter in versionParameters)
            {
                operation.Parameters.Remove(parameter);
            }
        }
    }
}
