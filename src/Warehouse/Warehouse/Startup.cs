using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Warehouse.Middleware;

namespace Warehouse
{

    /*
     * 1. Добавить обработку исключенй
     * 2. Добавить аутентификацию
     * 3. Добавить авторизацию (JWT токен)
     * 4. Swagger
     */

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Добавить сервисы для версионирования
            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });

            // 3 версии документации
            services.AddSwaggerGen(genOpts =>
            {
                genOpts.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API version 1",
                    Description = "API version 1 description"
                });

                genOpts.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v2",
                    Title = "API version 2",
                    Description = "API version 2 description"
                });

                genOpts.SwaggerDoc("v3", new OpenApiInfo
                {
                    Version = "v3",
                    Title = "API version 3",
                    Description = "API version 3 description"
                });

                // Удалить версию из параметров
                genOpts.OperationFilter<RemoveVersionFromParameter>();

                // Заменить версию в Route v{version:apiVersion} на реальную версию
                genOpts.DocumentFilter<ReplaceDocumentVersion>();

                genOpts.DocInclusionPredicate((version, desc) =>
                {
                    var versions = desc.ActionDescriptor.EndpointMetadata
                        .OfType<ApiVersionAttribute>()
                        .SelectMany(v => v.Versions);
                    return versions.Any(v => $"v{v.MajorVersion}" == version);
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger(o =>
            {
                o.RouteTemplate = "help/{documentname}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "My API V1");
                c.SwaggerEndpoint("v2/swagger.json", "My API V2");
                c.SwaggerEndpoint("v3/swagger.json", "My API V3");
                c.RoutePrefix = "help";
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
