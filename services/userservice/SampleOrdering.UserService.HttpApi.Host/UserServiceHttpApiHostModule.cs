using Microsoft.AspNetCore.Cors;
using SampleOrdering.Shared.Hosting.Microservices;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Modularity;
using SampleOrdering.Shared.Hosting.AspNetCore;
using SampleOrdering.UserService.Application;
using SampleOrdering.UserService.HttpApi.Host.DbMigrations;
using SampleOrdering.UserService.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
namespace SampleOrdering.UserService.HttpApi.Host
{
    [DependsOn(
        typeof(UserServiceHttpApiModule),
        typeof(UserServiceApplicationModule),
        typeof(UserServiceEntityFrameworkCoreModule),
        typeof(SharedHostingMicroservicesModule)
    )]
    public class UserServiceHttpApiHostModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            var hostingEnvironment = context.Services.GetHostingEnvironment();

            Configure<AbpDbConnectionOptions>(options =>
            {
               options.ConnectionStrings.Default = configuration.GetConnectionString("UserService");
            });
            Configure<AbpDbContextOptions>(options =>
            {
                options.UseNpgsql();
            });
            SwaggerConfigurationHelper.Configure(context: context, apiTitle: "User Service API");
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
                options.ConventionalControllers.Create(typeof(UserServiceApplicationModule).Assembly, opts =>
                {
                    opts.RootPath = "users";
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
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "User Service API");
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
