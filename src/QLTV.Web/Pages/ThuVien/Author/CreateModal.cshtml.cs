using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLTV.ThuVien.Dtos.Author;
using QLTV.ThuVien.Services;
using QLTV.Web.Pages.ThuVien.Author.ViewModels;

namespace QLTV.Web.Pages.ThuVien.Author
{
    public class CreateModalModel : QLTVPageModel
    {
        [BindProperty]
        public CreateEditAuthorViewModel ViewModel { get; set; }

        private readonly IAuthorAppService _service;

        public CreateModalModel(IAuthorAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditAuthorViewModel, AuthorRequest>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }

        //public void OnGet()
        //{
        //}
    }
}
