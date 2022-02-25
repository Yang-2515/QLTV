using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLTV.Services;
using QLTV.ThuVien.Dtos.Books;
using QLTV.ThuVien.Services;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.ObjectMapping;
using QLTV.Web.Pages;

namespace QLTV.Web.Pages.ThuVien.Book
{
    public class EditModalModel : QLTVPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public BookModel ViewModel { get; set; }
        public int CurrentNumber { get; set; }

        
        public List<SelectListItem> CategoryList { get; set; }

        public List<SelectListItem> AuthorList { get; set; }

        public List<SelectListItem> BlockList { get; set; }

        private readonly IBookAppService _service;

        private readonly ICategoryAppService _categoryAppService;

        private readonly IAuthorAppService _authorAppService;

        private readonly IBlockAppService _blockAppService;
        
        public EditModalModel(IBookAppService service, ICategoryAppService categoryAppService, IAuthorAppService authorAppService, IBlockAppService blockAppService)
        {
            _service = service;
            _categoryAppService = categoryAppService;
            _authorAppService = authorAppService;
            _blockAppService = blockAppService;

        }
        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<BookModel, BookRequest>(ViewModel);
            await _blockAppService.ChangeSpaceAndNumberBookInBlock(ViewModel.IdBlock, (ViewModel.NumberBook - _service.GetAsync(Id).Result.NumberBook));
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }

        public virtual async Task OnGetAsync()
        {
            var response = await _service.GetAsync(Id);

            this.ViewModel = ObjectMapper.Map<BookResponse, BookModel>(response);
            //this.ViewModel = ObjectMapper.Map<BookRequest, BookModel>(ObjectMapper.Map<BookResponse, BookRequest>(response));
            this.CurrentNumber = response.NumberBook;
            var categoryList = await _categoryAppService.GetListAsync(new PagedAndSortedResultRequestDto { MaxResultCount = 1000 });
            CategoryList = new List<SelectListItem>();
            
            foreach (var item in categoryList.Items)
            {
                if (item.Id.ToString() == this.ViewModel.IdCategory.ToString())
                {
                    CategoryList.Add(new SelectListItem
                    {
                        Value = item.Id.ToString(),
                        Text = item.NameCategory.ToString(),
                        Selected = true

                    }
                    );
                }
                else
                {
                    CategoryList.Add(new SelectListItem
                    {
                        Value = item.Id.ToString(),
                        Text = item.NameCategory.ToString()
                    });
                    

                    
                }
            }
            //---------------------
            var authorList = await _authorAppService.GetListAsync(new PagedAndSortedResultRequestDto { MaxResultCount = 1000 });
            AuthorList = new List<SelectListItem>();
            
            foreach (var item in authorList.Items)
            {
                if (item.Id.ToString() == this.ViewModel.IdAuthor.ToString())
                {
                    AuthorList.Add(new SelectListItem
                    {
                        Value = item.Id.ToString(),
                        Text = item.NameAuthor.ToString(),
                        Selected = true
                    }
                    );
                }
                else 
                {
                     AuthorList.Add(new SelectListItem
                     {
                       Value = item.Id.ToString(),
                       Text = item.NameAuthor.ToString()
                     });
                }
            }
            //-----------------
            var blockList = await _blockAppService.GetListAsync(new PagedAndSortedResultRequestDto { MaxResultCount = 1000 });
            BlockList = new List<SelectListItem>();
            
            foreach (var item in blockList.Items)
            {
                if(item.Id.ToString()==this.ViewModel.IdBlock.ToString())
                {
                    BlockList.Add(new SelectListItem
                    {
                        Value = item.Id.ToString(),
                        Text = item.NameBlock.ToString(),
                        Selected = true
                    }) ;
                }
                /*
                else
                {
                    BlockList.Add(new SelectListItem
                    {
                        Value = item.Id.ToString(),
                        Text = item.NameBlock.ToString()
                    });
                }*/
            }
            blockList = await _blockAppService.GetListEmptyBlock();
           // BlockList = new List<SelectListItem>();
            
            foreach (var item in blockList.Items)
            {
                BlockList.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.NameBlock.ToString()
                });
            }


        }
        public class BookModel : BookRequest
        {
            [SelectItems(nameof(CategoryList))]
            [Display(Name = "Category")]
            public override Guid IdCategory { get; set; }

            [SelectItems(nameof(AuthorList))]
            [Display(Name = "Author")]
            public override Guid IdAuthor { get; set; }

            [SelectItems(nameof(BlockList))]
            [Display(Name = "Block")]
            public override Guid IdBlock { get; set; }
        }
    }
}
