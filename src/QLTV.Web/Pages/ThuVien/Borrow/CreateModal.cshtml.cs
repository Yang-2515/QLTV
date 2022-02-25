using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using QLTV.Localization;
using QLTV.Services;
using QLTV.ThuVien.Dtos.Borrow;
using QLTV.ThuVien.Services;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace QLTV.Web.Pages.ThuVien.Borrow
{
    public class CreateModalModel : QLTVPageModel
    {
        [BindProperty]
        public BorrowModel ViewModel { get; set; }

        public List<SelectListItem> BookList { get; set; }
        public List<SelectListItem> ReaderList { get; set; }

        private readonly IBorrowAppService _service;
        private readonly IBookAppService _bookService;
        private readonly IReaderAppService _readerService;
        private readonly IBlockAppService _blockService;
        private readonly IStringLocalizer<QLTVResource> _localizer;

        public CreateModalModel(IBorrowAppService service, IBookAppService bookService, IReaderAppService readerService, IBlockAppService blockService, IStringLocalizer<QLTVResource> localizer)
        {
            _service = service;
            _bookService = bookService;
            _readerService = readerService;
            _blockService = blockService;
            _localizer = localizer;
        }

        public virtual async Task OnGetAsync()
        {
            var bookList = await _bookService.GetListAsync(new PagedAndSortedResultRequestDto { MaxResultCount = 1000 });
            BookList = new List<SelectListItem>();
            BookList.Add(new SelectListItem
            {
                Value = "",
                Text = _localizer["Select Book"],
                Selected = true
            });
            foreach (var item in bookList.Items)
            {
                BookList.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.NameBook.ToString()
                });
            }

            var readerList = await _readerService.GetListAsync(new PagedAndSortedResultRequestDto { MaxResultCount = 1000 });
            ReaderList = new List<SelectListItem>();
            ReaderList.Add(new SelectListItem
            {
                Value = "",
                Text = _localizer["Select Reader"],
                Selected = true
            });
            foreach (var item in readerList.Items)
            {
                ReaderList.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.NameReader.ToString()
                });
            }

        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            await _service.CreateAsync(ViewModel);
            await _blockService.ChangeSpace(ViewModel.IdBook, 1);
            await _bookService.ChangeNumberBook(ViewModel.IdBook, 1);
            return NoContent();
        }

        public class BorrowModel : BorrowRequest
        {
            [SelectItems(nameof(BookList))]
            [Display(Name = "Book")]
            public override Guid IdBook { get; set; }

            [SelectItems(nameof(ReaderList))]
            [Display(Name = "Reader")]
            public override Guid IdReader { get; set; }

        }
        //public void OnGet()
        //{
        //}
    }
}
