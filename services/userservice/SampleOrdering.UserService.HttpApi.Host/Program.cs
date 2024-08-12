using SampleOrdering.Shared.Hosting.AspNetCore;

namespace SampleOrdering.UserService.HttpApi.Host
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            var assemblyName = typeof(Program).Assembly.GetName().Name;

            try
            {
                var app = await ApplicationBuilderHelper
                    .BuildApplicationAsync<UserServiceHttpApiHostModule>(args);
                await app.InitializeApplicationAsync();
                await app.RunAsync();

                return 0;
            }
            catch (Exception)
            {
                return 1;
            }
        }
    }
}