using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using QLTV.Localization;
using QLTV.ThuVien.Services;
using Volo.Abp.Application.Dtos;

namespace QLTV.Web.Pages.ThuVien.Book
{
    public class IndexModel : QLTVPageModel
    {
        
        
        public List<SelectListItem> CategoryList { get; set; }

        private readonly ICategoryAppService _categoryAppService;

        private readonly IStringLocalizer<QLTVResource> _localizer;

        public IndexModel(ICategoryAppService categoryAppService, IStringLocalizer<QLTVResource> localizer)
        {
            _categoryAppService = categoryAppService;
            _localizer = localizer;
        }
        public virtual async Task OnGetAsync()
        {
            var categoryList = await _categoryAppService.GetListAsync(new PagedAndSortedResultRequestDto { MaxResultCount = 1000 });
            CategoryList = new List<SelectListItem>();
            CategoryList.Add(new SelectListItem
            {
                Value = "",
                Text = _localizer["Select Category"],
                Selected = true
            });
            foreach (var item in categoryList.Items)
            {
                CategoryList.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.NameCategory.ToString()
                });
            }
            await Task.CompletedTask;
        }
    }
}
