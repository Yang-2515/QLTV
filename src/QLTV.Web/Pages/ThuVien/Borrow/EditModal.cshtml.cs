using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLTV.Services;
using QLTV.ThuVien.Dtos.Borrow;
using QLTV.ThuVien.Services;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace QLTV.Web.Pages.ThuVien.Borrow
{
    public class EditModalModel : QLTVPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public BorrowModel ViewModel { get; set; }

        public List<SelectListItem> BookList { get; set; }
        public List<SelectListItem> ReaderList { get; set; }

        private readonly IBorrowAppService _service;

        private readonly IBookAppService _bookService;
        private readonly IReaderAppService _readerService;
        private readonly IBlockAppService _blockService;

        public EditModalModel(IBorrowAppService service, IBookAppService bookService, IReaderAppService readerService, IBlockAppService blockService)
        {
            _service = service;
            _bookService = bookService;
            _readerService = readerService;
            _blockService = blockService;
        }

        public virtual async Task OnGetAsync()
        {
            var response = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<BorrowResponse, BorrowModel>(response);

            var bookList = await _bookService.GetListAsync(new PagedAndSortedResultRequestDto { MaxResultCount = 1000 });
            BookList = new List<SelectListItem>();
            //BookList.Add(new SelectListItem
            //{
            //    Value = "",
            //    Text = "Chọn sách",
            //    Selected = true
            //});
            foreach (var item in bookList.Items)
            {
                if (item.Id.ToString() == this.ViewModel.IdBook.ToString())
                {
                    BookList.Add(new SelectListItem
                    {
                        Value = item.Id.ToString(),
                        Text = item.NameBook.ToString(),
                        Selected = true

                    }
                    );
                }
                else
                {
                    BookList.Add(new SelectListItem
                    {
                        Value = item.Id.ToString(),
                        Text = item.NameBook.ToString()
                    });
                }
                //BookList.Add(new SelectListItem
                //{
                //    Value = item.Id.ToString(),
                //    Text = item.NameBook.ToString()
                //});
            }

            var readerList = await _readerService.GetListAsync(new PagedAndSortedResultRequestDto { MaxResultCount = 1000 });
            ReaderList = new List<SelectListItem>();
            //ReaderList.Add(new SelectListItem
            //{
            //    Value = "",
            //    Text = "Chọn người đọc",
            //    Selected = true
            //});
            foreach (var item in readerList.Items)
            {
                if (item.Id.ToString() == this.ViewModel.IdBook.ToString())
                {
                    ReaderList.Add(new SelectListItem
                    {
                        Value = item.Id.ToString(),
                        Text = item.NameReader.ToString(),
                        Selected = true

                    }
                    );
                }
                else
                {
                    ReaderList.Add(new SelectListItem
                    {
                        Value = item.Id.ToString(),
                        Text = item.NameReader.ToString()
                    });
                }
                //ReaderList.Add(new SelectListItem
                //{
                //    Value = item.Id.ToString(),
                //    Text = item.NameReader.ToString()
                //});
            }
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            if(ViewModel.IsReturnBook == true && _service.GetAsync(Id).Result.IsReturnBook == false)
            {
                await _blockService.ChangeSpace(ViewModel.IdBook, -1);
                await _bookService.ChangeNumberBook(ViewModel.IdBook, -1);
            }
            if (ViewModel.IsReturnBook == false && _service.GetAsync(Id).Result.IsReturnBook == true)
            {
                await _blockService.ChangeSpace(ViewModel.IdBook, 1);
                await _bookService.ChangeNumberBook(ViewModel.IdBook, 1);
            }
            var dto = ObjectMapper.Map<BorrowModel, BorrowRequest>(ViewModel);
            await _service.UpdateAsync(Id, ViewModel);
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
