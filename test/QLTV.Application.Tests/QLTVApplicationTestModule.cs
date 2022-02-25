using Volo.Abp.Modularity;

namespace QLTV
{
    [DependsOn(
        typeof(QLTVApplicationModule),
        typeof(QLTVDomainTestModule)
        )]
    public class QLTVApplicationTestModule : AbpModule
    {

    }
}