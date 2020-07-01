using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Middleware
{
    public class ReplaceDocumentVersion : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var paths = new OpenApiPaths();
            foreach (var pair in swaggerDoc.Paths)
            {
                var key = pair.Key.Replace("v{version}", swaggerDoc.Info.Version);
                paths.Add(key, pair.Value);
            }

            swaggerDoc.Paths = paths;
        }
    }
}
