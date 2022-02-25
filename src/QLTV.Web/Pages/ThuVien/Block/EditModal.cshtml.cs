using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLTV.Services;
using QLTV.ThuVien.Dtos.Block;

namespace QLTV.Web.Pages.ThuVien.Block
{
    public class EditModalModel : QLTVPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public BlockRequest ViewModel { get; set; }

        private readonly IBlockAppService _service;

        public EditModalModel(IBlockAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var response = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<BlockResponse, BlockRequest>(response);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            await _service.UpdateAsync(Id, ViewModel);
            return NoContent();
        }
    }
}