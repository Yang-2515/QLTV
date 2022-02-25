using Microsoft.AspNetCore.Mvc;
using QLTV.Repositories;
using QLTV.Services;
using QLTV.ThuVien.Dtos.Books;
using QLTV.ThuVien.Dtos.Search;
using QLTV.ThuVien.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace QLTV.ThuVien
{
    public class BookAppService : CrudAppService<
        Book,
        BookResponse,
        Guid,
        PagedAndSortedResultRequestDto,
        BookRequest,
        BookRequest>,
        IBookAppService
    {
        private readonly IBookRepository _repository;
        private readonly IBorrowRepository _borrowRepository;
        private readonly IBlockAppService _blockAppService;
        public BookAppService(
            IBookRepository repository, IBorrowRepository borrowRepository, IBlockAppService blockAppService) : base(repository)
        {
            _repository = repository;
            _borrowRepository = borrowRepository;
            _blockAppService = blockAppService;
        }

        [HttpGet]
        public async Task<PagedResultDto<BookResponse>> SearchAsync(Dtos.Search.ConditionSearchRequest condition)
        {
            var input = new PagedAndSortedResultRequestDto { MaxResultCount = 1000, SkipCount = 0 };
            if (condition.keyword == null)
            {
                condition.keyword = "";
            }
            PagedResultDto<BookResponse> listResultDto = new PagedResultDto<BookResponse>();
            var list = this.GetListAsync(input).Result;
            var resultSearch = list.Items.Where(x => x.NameBook.ToLower().Contains(condition.keyword.ToLower()) || x.CategoryBook.ToLower().Contains(condition.keyword.ToLower())
                                                      || x.AuthorBook.ToLower().Contains(condition.keyword.ToLower()) || x.BlockBook.ToLower().Contains(condition.keyword.ToLower()));
            listResultDto.TotalCount = resultSearch.Count();
            listResultDto.Items = resultSearch.Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();
            return listResultDto;
        }
        [HttpGet]
        public async Task<PagedResultDto<BookResponse>> AdvancedSearchAsync(AdvancedSearch condition)
        {
            var input = new PagedAndSortedResultRequestDto { MaxResultCount = 1000, SkipCount = 0 };
            if (condition.keyword == null)
            {
                condition.keyword = "";
            }
            if (condition.category == null)
            {
                condition.category = "";
            }
            PagedResultDto<BookResponse> listResultDto = new PagedResultDto<BookResponse>();
            PagedResultDto<Book> listResultBook = new PagedResultDto<Book>();
            /*
            var list = this.GetListAsync(input).Result;
            
            var resultSearch = list.Items.Where(x => x.NameBook.ToLower().Contains(condition.keyword.ToLower()) || x.CategoryBook.ToLower().Contains(condition.keyword.ToLower())).Where(c=>c.Price >= condition.minPrice && c.Price <=condition.maxPrice );
            listResultDto.TotalCount = resultSearch.Count();
            listResultDto.Items = resultSearch.Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();
            return listResultDto;*/
            PagedResultDto<Book> list = await _repository.GetListAsync(input);
            
            var resultSearch = list.Items.Where(x => x.NameBook.ToLower().Contains(condition.keyword.ToLower()) ||  x.CategoryBook.NameCategory.ToLower().Contains(condition.keyword.ToLower()) || x.AuthorBook.NameAuthor.ToLower().Contains(condition.keyword.ToLower()) || x.BlockBook.NameBlock.ToLower().Contains(condition.keyword.ToLower())).Where(c => c.Price >= condition.minPrice && c.Price <= condition.maxPrice).Where(c=>c.CategoryBook.Id.ToString().Contains(condition.category));
            listResultBook.TotalCount = resultSearch.Count();
            listResultBook.Items = resultSearch.Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();
            return await this.BookToBookResponseAsync(listResultBook);

        }

        [HttpGet]
        public override async Task<PagedResultDto<BookResponse>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            /*PagedResultDto<BookResponse> listResultDto = new PagedResultDto<BookResponse>();
            var list = this.GetListAsync(input).Result;
            var result = list.Items;
            listResultDto.TotalCount = result.Count();
            listResultDto.Items = result.ToList();
            return listResultDto;*/
            
            PagedResultDto<Book> items = await _repository.GetListAsync(input);
            List<BookResponse> bookResponses = new List<BookResponse>();
            PagedResultDto<Borrow> borrowList = await _borrowRepository.GetListAsync(input);

            foreach (var item in items.Items)
            {
                //int unavailableBooks = borrowList.Items.Where(c => c.IdBook.ToString() == item.Id.ToString() && c.IsReturnBook == false).Count();
                var bookResponse = ObjectMapper.Map<Book, BookResponse>(item);
                bookResponse.AuthorBook = item.AuthorBook == null ? "" : item.AuthorBook.NameAuthor;
                bookResponse.CategoryBook = item.CategoryBook == null ? "" : item.CategoryBook.NameCategory;
                bookResponse.BlockBook = item.BlockBook == null ? "" : item.BlockBook.NameBlock;
               // bookResponse.NumberBook -= unavailableBooks;
                bookResponses.Add(bookResponse);
            }
            return new PagedResultDto<BookResponse>(items.TotalCount, bookResponses);


        }
        [HttpGet]
        public async Task<PagedResultDto<BookResponse>> BookToBookResponseAsync(PagedResultDto<Book> items)
        {
            var input = new PagedAndSortedResultRequestDto { MaxResultCount = 1000, SkipCount = 0 };
            List<BookResponse> bookResponses = new List<BookResponse>();
            PagedResultDto<Borrow> borrowList = await _borrowRepository.GetListAsync(input);

            foreach (var item in items.Items)
            {
               // int unavailableBooks = borrowList.Items.Where(c => c.IdBook.ToString() == item.Id.ToString() && c.IsReturnBook == false).Count();
                var bookResponse = ObjectMapper.Map<Book, BookResponse>(item);
                bookResponse.AuthorBook = item.AuthorBook == null ? "" : item.AuthorBook.NameAuthor;
                bookResponse.CategoryBook = item.CategoryBook == null ? "" : item.CategoryBook.NameCategory;
                bookResponse.BlockBook = item.BlockBook == null ? "" : item.BlockBook.NameBlock;
              //  bookResponse.NumberBook -= unavailableBooks;
                bookResponses.Add(bookResponse);
            }
            return new PagedResultDto<BookResponse>(items.TotalCount, bookResponses);


        }
        public async Task ChangeNumberBook(Guid idBook, int i)
        {
            var book = this.GetAsync(idBook);
            if (book != null)
            {
                book.Result.NumberBook -= i;
                await this.UpdateAsync(book.Result.Id, ObjectMapper.Map<BookResponse, BookRequest>(book.Result));
            }
        }

        public async Task<bool> CheckExistingBook(string name, string author)
        {
            if (name == null || author == null) return false;
            var input = new PagedAndSortedResultRequestDto { MaxResultCount = 1000, SkipCount = 0 };
            PagedResultDto<BookResponse> listBook = new PagedResultDto<BookResponse>();
            listBook =await this.GetListAsync(input);
            foreach (var item in listBook.Items)
            {
                if (item.IdAuthor.ToString().ToLower().Trim() == author.ToString().ToLower().Trim() 
                    && item.NameBook.ToString().ToLower().Trim() == name.ToString().ToLower().Trim()) 
                    return true;
            }
            return false;
        }

        public async Task<bool> CheckExistingBookWithId(string name, string author, string id)
        {
            if (name == null || author == null  || id == null) return false;
            var input = new PagedAndSortedResultRequestDto { MaxResultCount = 1000, SkipCount = 0 };
            PagedResultDto<BookResponse> listBook = new PagedResultDto<BookResponse>();
            listBook = await this.GetListAsync(input);
            foreach (var item in listBook.Items)
            {
                if (item.IdAuthor.ToString().ToLower().Trim() == author.ToString().ToLower().Trim()
                    && item.NameBook.ToString().ToLower().Trim() == name.ToString().ToLower().Trim() 
                    && item.Id.ToString() != id.ToString())
                    return true;
            }
            return false;
        }
        

        public async Task ChangeNumberBookForDelete(Guid idBook)
        {
            var book = this.GetAsync(idBook);
            if (book != null)
            {
                await _blockAppService.ChangeSpaceAndNumberBookInBlock(Guid.Parse(book.Result.IdBlock), - book.Result.NumberBook);
                await this.UpdateAsync(book.Result.Id, ObjectMapper.Map<BookResponse, BookRequest>(book.Result));
            }
        }
    }
}
