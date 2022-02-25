using QLTV.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace QLTV.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class QLTVController : AbpController
    {
        protected QLTVController()
        {
            LocalizationResource = typeof(QLTVResource);
        }
    }
}