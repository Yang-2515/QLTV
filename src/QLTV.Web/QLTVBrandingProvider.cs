using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace QLTV.Web
{
    [Dependency(ReplaceServices = true)]
    public class QLTVBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Team Alpha";
        public override string LogoUrl => "https://cdn.dribbble.com/users/1218981/screenshots/15747645/media/3d37249486d1910ff0b4f18eca1c4130.jpg?compress=1&resize=400x300";
    }
}
