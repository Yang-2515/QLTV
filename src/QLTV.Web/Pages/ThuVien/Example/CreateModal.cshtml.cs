using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLTV.ThuVien;
using QLTV.ThuVien.Dtos;
using QLTV.Web.Pages.ThuVien.Example.ViewModels;

namespace QLTV.Web.Pages.ThuVien.Example
{
    public class CreateModalModel : QLTVPageModel
    {
        [BindProperty]
        public CreateEditExampleViewModel ViewModel { get; set; }

        private readonly IExampleAppService _service;

        public CreateModalModel(IExampleAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditExampleViewModel, CreateUpdateExampleDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}