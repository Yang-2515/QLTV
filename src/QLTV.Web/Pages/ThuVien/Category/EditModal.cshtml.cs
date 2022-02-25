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
    public class EditModalModel : QLTVPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditCategoryViewModel ViewModel { get; set; }

        private readonly ICategoryAppService _service;
        public EditModalModel(ICategoryAppService service)
        {
            _service = service;
        }
        public virtual async Task OnGetAsync()
        {
            var response = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<CategoryResponse, CreateEditCategoryViewModel>(response);
        }
        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditCategoryViewModel, CategoryRequest>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}
