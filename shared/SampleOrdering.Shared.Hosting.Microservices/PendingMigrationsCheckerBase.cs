using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp;

namespace SampleOrdering.Shared.Hosting.Microservices
{
    public abstract class PendingMigrationsCheckerBase : ITransientDependency
    {
        public async Task TryAsync(Func<Task> task, int retryCount = 3)
        {
            try
            {
                await task();
            }
            catch (Exception ex)
            {
                retryCount--;

                if (retryCount <= 0)
                {
                    throw;
                }

                await Task.Delay(RandomHelper.GetRandom(5000, 15000));

                await TryAsync(task, retryCount);
            }
        }
    }
}
