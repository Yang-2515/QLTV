using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLTV.Services;
using QLTV.ThuVien.Dtos.Block;
using QLTV.Web.Pages.ThuVien.Block;

namespace QLTV.Web.Pages.ThuVien.Block
{
    public class CreateModalModel : QLTVPageModel
    {
        [BindProperty]
        public BlockRequest ViewModel { get; set; }

        private readonly IBlockAppService _service;

        public CreateModalModel(IBlockAppService service)
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