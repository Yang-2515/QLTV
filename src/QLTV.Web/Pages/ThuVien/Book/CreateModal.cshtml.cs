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
using QLTV.ThuVien.Dtos.Books;
using QLTV.ThuVien.Services;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.Localization;

namespace QLTV.Web.Pages.ThuVien.Book
{
    public class CreateModalModel : QLTVPageModel
    {
        [BindProperty]
        public BookModel ViewModel { get; set; }
        public List<SelectListItem> CategoryList { get; set; }

        public List<SelectListItem> AuthorList { get; set; }

        public List<SelectListItem> BlockList { get; set; }

        private readonly IBookAppService _service;

        private readonly ICategoryAppService _categoryAppService;

        private readonly IAuthorAppService _authorAppService;

        private readonly IBlockAppService _blockAppService;

        private readonly IStringLocalizer<QLTVResource> _localizer;
        public CreateModalModel(IBookAppService service, ICategoryAppService categoryAppService,IAuthorAppService authorAppService,IBlockAppService blockAppService, IStringLocalizer<QLTVResource> localizer)
        {
            _service = service;
            _categoryAppService = categoryAppService;
            _authorAppService = authorAppService;
            _blockAppService = blockAppService;
            _localizer = localizer;
            
        }
        public virtual async Task OnGetAsync()
        {
            var categoryList = await _categoryAppService.GetListAsync(new PagedAndSortedResultRequestDto { MaxResultCount = 1000 });
            CategoryList = new List<SelectListItem>();
            CategoryList.Add(new SelectListItem
            {
                Value = "",
                Text = _localizer["Select Category"],
                Selected = true
            });
            foreach (var item in categoryList.Items)
            {
                CategoryList.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.NameCategory.ToString()
                });
            }
            //---------------------
            var authorList = await _authorAppService.GetListAsync(new PagedAndSortedResultRequestDto { MaxResultCount = 1000 });
            AuthorList = new List<SelectListItem>();
            AuthorList.Add(new SelectListItem
            {
                Value = "",
                Text = _localizer["Select Author"],
                Selected = true
            });
            foreach (var item in authorList.Items)
            {
                AuthorList.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.NameAuthor.ToString()
                });
            }
            //-----------------
            var blockList = await _blockAppService.GetListEmptyBlock();
            BlockList = new List<SelectListItem>();
            BlockList.Add(new SelectListItem
            {
                Value = "",
                Text = _localizer["Select Block"],
                Selected = true
            });
            foreach (var item in blockList.Items)
            {
                BlockList.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.NameBlock.ToString()
                });
            }

        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            await _service.CreateAsync(ViewModel);
            await _blockAppService.ChangeSpaceAndNumberBookInBlock(ViewModel.IdBlock, ViewModel.NumberBook);
            return NoContent();
        }

        public class BookModel : BookRequest
        {
            [SelectItems(nameof(CategoryList))]
            [Display(Name = "Category",Prompt ="Select Category")]
            public override Guid IdCategory { get; set; }

            [SelectItems(nameof(AuthorList))]
            [Display(Name = "Author", Prompt = "Select Author")]
            public override Guid IdAuthor { get; set; }

            [SelectItems(nameof(BlockList))]
            [Display(Name = "Block", Prompt = "Select Block")]
            public override Guid IdBlock { get; set; }
        }
    }
}
