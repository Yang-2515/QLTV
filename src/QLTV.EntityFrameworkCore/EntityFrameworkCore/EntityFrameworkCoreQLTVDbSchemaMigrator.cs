using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QLTV.Data;
using Volo.Abp.DependencyInjection;

namespace QLTV.EntityFrameworkCore
{
    public class EntityFrameworkCoreQLTVDbSchemaMigrator
        : IQLTVDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreQLTVDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the QLTVDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<QLTVDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
