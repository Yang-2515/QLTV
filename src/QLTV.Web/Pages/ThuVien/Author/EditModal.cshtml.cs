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
    public class EditModalModel : QLTVPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditAuthorViewModel ViewModel { get; set; }

        private readonly IAuthorAppService _service;

        public EditModalModel(IAuthorAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var response = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<AuthorResponse, CreateEditAuthorViewModel>(response);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditAuthorViewModel, AuthorRequest>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
        //public void OnGet()
        //{
        //}
    }
}
