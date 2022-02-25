using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLTV.Services;
using QLTV.ThuVien.Dtos.Reader;
using QLTV.Web.Pages;

namespace QLTV.Web.Pages.ThuVien.Reader
{
    public class CreateModalModel : QLTVPageModel
    {
        [BindProperty]
        public ReaderRequest ViewModel { get; set; }

        private readonly IReaderAppService _service;

        public CreateModalModel(IReaderAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            await _service.CreateAsync(ViewModel);
            return NoContent();
        }
    }
}