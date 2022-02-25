using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLTV.ThuVien;
using QLTV.ThuVien.Dtos;
using QLTV.Web.Pages.ThuVien.Example.ViewModels;

namespace QLTV.Web.Pages.ThuVien.Example
{
    public class EditModalModel : QLTVPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditExampleViewModel ViewModel { get; set; }

        private readonly IExampleAppService _service;

        public EditModalModel(IExampleAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<ExampleDto, CreateEditExampleViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditExampleViewModel, CreateUpdateExampleDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}