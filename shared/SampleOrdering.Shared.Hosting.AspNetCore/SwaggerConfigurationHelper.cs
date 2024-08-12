using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;

namespace SampleOrdering.Shared.Hosting.AspNetCore
{

    public static class SwaggerConfigurationHelper
    {
        public static void ConfigureWithOidc(
            ServiceConfigurationContext context,
            string authority,
            string[] scopes,
            string apiTitle,
            string apiVersion = "v1",
            string apiName = "v1",
            string[]? flows = null,
            string? discoveryEndpoint = null
        )
        {
            context.Services.AddAbpSwaggerGenWithOidc(
                authority: authority,
                scopes: scopes,
                flows: flows,
                discoveryEndpoint: discoveryEndpoint,
                options =>
                {
                    options.SwaggerDoc(apiName, new OpenApiInfo { Title = apiTitle, Version = apiVersion });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);
                });
        }
        public static void Configure(
            ServiceConfigurationContext context,
            string apiTitle,
            string apiVersion = "v1",
            string apiName = "v1",
            string? discoveryEndpoint = null
        )
        {
            context.Services.AddAbpSwaggerGen(options =>
            {
                options.SwaggerDoc(apiName, new OpenApiInfo { Title = apiTitle, Version = apiVersion });
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
            });
        }
    }
}
