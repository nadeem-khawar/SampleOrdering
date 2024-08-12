using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;

namespace SampleOrdering.Shared.Hosting.AspNetCore
{
    public static class ApplicationBuilderHelper
    {
        public static async Task<WebApplication> BuildApplicationAsync<TStartupModule>(string[] args)
            where TStartupModule : IAbpModule
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Host
                .AddAppSettingsSecretsJson()
                .UseAutofac();

            await builder.AddApplicationAsync<TStartupModule>();
            return builder.Build();
        }
    }
}
