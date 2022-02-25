using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLTV.Services;
using QLTV.ThuVien.Dtos.Categories;
using QLTV.ThuVien.Services;
using QLTV.Web.Pages.ThuVien.Category.ViewModels;

namespace QLTV.Web.Pages.ThuVien.Category
{
    public class CreateModalModel : QLTVPageModel
    {
        [BindProperty]
        //public CategoryRequest ViewModel { get; set; }
        public CreateEditCategoryViewModel ViewModel { get; set; }
        private readonly ICategoryAppService _service;

        public CreateModalModel(ICategoryAppService service)
        {
            _service = service;
        }
        public virtual async Task OnGetAsync()
        {

        }
        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditCategoryViewModel, CategoryRequest>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
        

    }
}
