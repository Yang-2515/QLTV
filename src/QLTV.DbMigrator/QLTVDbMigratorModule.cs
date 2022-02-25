using QLTV.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace QLTV.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(QLTVEntityFrameworkCoreModule),
        typeof(QLTVApplicationContractsModule)
        )]
    public class QLTVDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
