using QLTV.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace QLTV
{
    [DependsOn(
        typeof(QLTVEntityFrameworkCoreTestModule)
        )]
    public class QLTVDomainTestModule : AbpModule
    {

    }
}