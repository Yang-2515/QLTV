using QLTV.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace QLTV.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class QLTVPageModel : AbpPageModel
    {
        protected QLTVPageModel()
        {
            LocalizationResourceType = typeof(QLTVResource);
        }
    }
}