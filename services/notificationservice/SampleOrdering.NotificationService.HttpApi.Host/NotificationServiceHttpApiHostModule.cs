﻿using SampleOrdering.NotificationService.Application;
using SampleOrdering.Shared.Hosting.AspNetCore;
using SampleOrdering.Shared.Hosting.Microservices;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Data;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace SampleOrdering.NotificationService.HttpApi.Host
{
    [DependsOn(
        typeof(NotificationServiceHttpApiModule),
        typeof(NotificationServiceApplicationModule),
        typeof(SharedHostingMicroservicesModule)
    )]
    public class NotificationServiceHttpApiHostModule: AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            var hostingEnvironment = context.Services.GetHostingEnvironment();

            SwaggerConfigurationHelper.Configure(context: context, apiTitle: "Notification Service API");
            /*context.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                        .WithOrigins(
                            configuration["App:CorsOrigins"]!
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.Trim().RemovePostFix("/"))
                                .ToArray()
                        )
                        .WithAbpExposedHeaders()
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });*/


            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(NotificationServiceApplicationModule).Assembly, opts =>
                {
                    opts.RootPath = "Notifications";
                });
            });
        }
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCorrelationId();
            app.UseCors();
            app.UseAbpRequestLocalization();
            app.UseStaticFiles();
            app.UseRouting();
            //app.UseAuthentication();
            //app.UseAbpClaimsMap();
            //app.UseAuthorization();
            app.UseSwagger();
            app.UseAbpSwaggerWithCustomScriptUI(options =>
            {
                var configuration = context.ServiceProvider.GetRequiredService<IConfiguration>();
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Order Service API");
            });
            app.UseAuditing();
            app.UseUnitOfWork();
            app.UseConfiguredEndpoints();
        }
        /*public override async Task OnPostApplicationInitializationAsync(ApplicationInitializationContext context)
        {
            await context.ServiceProvider
                .GetRequiredService<UserServiceDatabaseMigrationChecker>()
                .CheckAndApplyDatabaseMigrationsAsync();
        }*/
    }
}
