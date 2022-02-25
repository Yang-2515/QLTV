using System;
using System.Collections.Generic;
using System.Text;
using QLTV.Localization;
using Volo.Abp.Application.Services;

namespace QLTV
{
    /* Inherit your application services from this class.
     */
    public abstract class QLTVAppService : ApplicationService
    {
        protected QLTVAppService()
        {
            LocalizationResource = typeof(QLTVResource);
        }
    }
}
