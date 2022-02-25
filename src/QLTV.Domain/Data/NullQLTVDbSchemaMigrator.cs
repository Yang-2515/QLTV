using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace QLTV.Data
{
    /* This is used if database provider does't define
     * IQLTVDbSchemaMigrator implementation.
     */
    public class NullQLTVDbSchemaMigrator : IQLTVDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}