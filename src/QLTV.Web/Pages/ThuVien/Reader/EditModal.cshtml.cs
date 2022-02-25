using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLTV.Services;
using QLTV.ThuVien.Dtos.Reader;

namespace QLTV.Web.Pages.ThuVien.Reader
{
    public class EditModalModel : QLTVPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public ReaderRequest ViewModel { get; set; }

        private readonly IReaderAppService _service;

        public EditModalModel(IReaderAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var response = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<ReaderResponse, ReaderRequest>(response);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            await _service.UpdateAsync(Id, ViewModel);
            return NoContent();
        }
    }
}