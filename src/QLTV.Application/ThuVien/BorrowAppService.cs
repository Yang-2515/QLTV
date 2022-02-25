using Microsoft.AspNetCore.Mvc;
using QLTV.Repositories;
using QLTV.ThuVien.Dtos.Books;
using QLTV.ThuVien.Dtos.Borrow;
using QLTV.ThuVien.Dtos.Categories;
using QLTV.ThuVien.Dtos.Reader;
using QLTV.ThuVien.Dtos.TopBook;
using QLTV.ThuVien.Dtos.TopCategory;
using QLTV.ThuVien.Dtos.TopReader;
using QLTV.ThuVien.Search;
using QLTV.ThuVien.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace QLTV.ThuVien
{
    public class BorrowAppService :
        CrudAppService<Borrow,
            BorrowResponse, Guid, PagedAndSortedResultRequestDto,
            BorrowRequest, BorrowRequest>,
        IBorrowAppService
    {
        private readonly IBorrowRepository _repository;
        private readonly ICategoryRepository _repositoryCategory;
        private readonly IBookRepository _repositoryBook;
        private readonly IReaderRepository _repositoryReader;
        public BorrowAppService(IBorrowRepository Borrows,
            ICategoryRepository Categories,
            IBookRepository Books,
            IReaderRepository Readers,
        IRepository<Borrow, Guid> repository) : base(repository)
        {
            _repository = Borrows;
            _repositoryCategory = Categories;
            _repositoryBook = Books;
            _repositoryReader = Readers;
        }

        public async override Task<PagedResultDto<BorrowResponse>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            PagedResultDto<Borrow> items = await _repository.GetListAsync(input);
            List<BorrowResponse> borrowResponses = new List<BorrowResponse>();
            foreach (var item in items.Items)
            {
                var borrowResponse = ObjectMapper.Map<Borrow, BorrowResponse>(item);
                borrowResponse.BookBorrow = item.BookBorrow == null ? "" : item.BookBorrow.NameBook;
                borrowResponse.ReaderBorrow = item.ReaderBorrow == null ? "" : item.ReaderBorrow.NameReader;
                borrowResponses.Add(borrowResponse);
            }
            return new PagedResultDto<BorrowResponse>(items.TotalCount, borrowResponses);
        }

        [HttpGet]
        public async Task<PagedResultDto<BorrowResponse>> SearchAsync(ConditionSearchRequest condition)
        {
            var input = new PagedAndSortedResultRequestDto { MaxResultCount = 1000, SkipCount = 0 };
            if (condition.keyword == null)
            {
                condition.keyword = "";
            }

            //PagedResultDto<BorrowResponse> listResultDto = new PagedResultDto<BorrowResponse>();
            //var list = this.GetListAsync(input).Result;
            //var resultSearch = list.Items.Where(x => x.DateBorrow == Convert.ToDateTime(condition.keyword));
            //listResultDto.TotalCount = resultSearch.Count();
            //listResultDto.Items = resultSearch.Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();
            //return listResultDto;

            //PagedResultDto<BorrowResponse> listResultDto = new PagedResultDto<BorrowResponse>();
            //var items = await _repository.GetListAsync(input);
            //var resultSearch = items.Items.Where(x => x.ReaderBorrow.NameReader == condition.keyword || x.BookBorrow.NameBook == condition.keyword);
            //listResultDto.TotalCount = resultSearch.Count();
            //listResultDto.Items = (IReadOnlyList<BorrowResponse>)resultSearch.Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();
            //return listResultDto;
            PagedResultDto<Borrow> items = await _repository.GetListAsync(input);
            List<BorrowResponse> borrowResponses = new List<BorrowResponse>();
            foreach (var item in items.Items)
            {
                var borrowResponse = ObjectMapper.Map<Borrow, BorrowResponse>(item);
                borrowResponse.BookBorrow = item.BookBorrow == null ? "" : item.BookBorrow.NameBook;
                borrowResponse.ReaderBorrow = item.ReaderBorrow == null ? "" : item.ReaderBorrow.NameReader;
                if(item.ReaderBorrow.NameReader.ToLower().Contains(condition.keyword.ToLower()) 
                    || item.BookBorrow.NameBook.ToLower().Contains(condition.keyword.ToLower()) 
                    || Convert.ToDateTime(item.DateBorrow).ToString("dd/MM/yyyy").Contains(condition.keyword) 
                    || Convert.ToDateTime(item.DateReturn).ToString("dd/MM/yyyy").Contains(condition.keyword))
                {
                    borrowResponses.Add(borrowResponse);
                }
                else
                {
                    items.TotalCount -= 1;
                }
                
            }
            return new PagedResultDto<BorrowResponse>(items.TotalCount, borrowResponses);
        }

        

        [HttpGet]
        public async Task<PagedResultDto<TopReaderResponse>> GetListTopReaderAsync(ConditionSearchRequest condition)
        {
            var input = new PagedAndSortedResultRequestDto { MaxResultCount = 1000, SkipCount = 0 };
            PagedResultDto<Borrow> list = await _repository.GetListAsync(input);
            PagedResultDto<TopReaderResponse> listResultDto = new PagedResultDto<TopReaderResponse>();
            List<TopReaderResponse> listResult = new List<TopReaderResponse>();
            var query = from borrow in list.Items
                        group borrow by borrow.ReaderBorrow.Id into readerBorrow
                        orderby readerBorrow.Count() descending
                        select new 
                        {
                            Reader = readerBorrow.Key,
                            CountBorrow = readerBorrow.Count(),
                        };
            var reader = query.ToList();
            for(int i = 0; i < reader.Count; i++)
            {
                Reader item = await _repositoryReader.GetAsync(reader[i].Reader);
                var readerResponse = ObjectMapper.Map<Reader, ReaderResponse>(item);
                TopReaderResponse topReaderResponse = new TopReaderResponse();
                topReaderResponse.Reader = readerResponse;
                topReaderResponse.CountBorrow = reader[i].CountBorrow;
                listResult.Add(topReaderResponse);
            }
            listResultDto.TotalCount = listResult.Count();
            listResultDto.Items = listResult.Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();
            return listResultDto;
        }

        [HttpGet]
        public async Task<PagedResultDto<TopBookResponse>> GetListTopBookAsync(ConditionSearchRequest condition)
        {
            var input = new PagedAndSortedResultRequestDto { MaxResultCount = 1000, SkipCount = 0 };
            PagedResultDto<Borrow> list = await _repository.GetListAsync(input);
            PagedResultDto<TopBookResponse> listResultDto = new PagedResultDto<TopBookResponse>();
            List<TopBookResponse> listResult = new List<TopBookResponse>();
            var query = from borrow in list.Items
                        group borrow by borrow.BookBorrow.Id into readerBorrow
                        orderby readerBorrow.Count() descending
                        select new 
                        {
                            Book = readerBorrow.Key,
                            CountBorrow = readerBorrow.Count(),
                        };
            var reader = query.ToList();
            for (int i = 0; i < reader.Count; i++)
            {
                Book item = await _repositoryBook.GetAsync(reader[i].Book);
                var bookResponse = ObjectMapper.Map<Book, BookResponse>(item);
                bookResponse.AuthorBook = item.AuthorBook == null ? "" : item.AuthorBook.NameAuthor;
                bookResponse.CategoryBook = item.CategoryBook == null ? "" : item.CategoryBook.NameCategory;
                bookResponse.BlockBook = item.BlockBook == null ? "" : item.BlockBook.NameBlock;
                TopBookResponse topBookResponse = new TopBookResponse();
                topBookResponse.Book = bookResponse;
                topBookResponse.CountBorrow = reader[i].CountBorrow;
                listResult.Add(topBookResponse);
            }
            listResultDto.TotalCount = listResult.Count();
            listResultDto.Items = listResult.Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();
            return listResultDto;
        }

        [HttpGet]
        public async Task<PagedResultDto<BorrowResponse>> GetIsReturnBookAsync(ConditionSearchRequest condition)
        {
            var input = new PagedAndSortedResultRequestDto { MaxResultCount = 1000, SkipCount = 0 };
            PagedResultDto<BorrowResponse> listResultDto = new PagedResultDto<BorrowResponse>();
            var list = this.SearchAsync(new ConditionSearchRequest { keyword = condition.keyword, MaxResultCount = 1000, SkipCount = 0 }).Result;
            listResultDto.TotalCount = 0;
            listResultDto.Items = null;
            if(condition.keywordCombobox.Equals("none"))
            {
                condition.keywordCombobox = "";
            }
            if (condition.keywordCombobox.Equals("Yes"))
            {
                var resultSearch = list.Items.Where(x => x.IsReturnBook.Equals(true));
                listResultDto.TotalCount = resultSearch.Count();
                listResultDto.Items = resultSearch.Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();
            }
            else if (condition.keywordCombobox.Equals("No"))
            {
                var resultSearch = list.Items.Where(x => x.IsReturnBook.Equals(false));
                listResultDto.TotalCount = resultSearch.Count();
                listResultDto.Items = resultSearch.Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();
            }
            else
            {
                var resultSearch = list.Items.Select(x => x);
                listResultDto.TotalCount = resultSearch.Count();
                listResultDto.Items = resultSearch.Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();
            }
            return listResultDto;
        }

        [HttpGet]
        public async Task<List<TopCategoryResponse>> GetListTopCategoryAsync()
        {
            var input = new PagedAndSortedResultRequestDto { MaxResultCount = 1000, SkipCount = 0 };
            PagedResultDto<Category> categories = await _repositoryCategory.GetListAsync(input);
            List<TopCategoryResponse> listResult = new List<TopCategoryResponse>();
            PagedResultDto<Borrow> list = await _repository.GetListAsync(input);
            PagedResultDto<Book> listBook = await _repositoryBook.GetListAsync(input);
            var query1 = from p in list.Items
                         join c in categories.Items on p.BookBorrow.IdCategory equals c.Id
                         select new
                         {
                             BookName = p.BookBorrow.NameBook,
                             CategoryId = c.Id
                         };
            var query = from item in query1.ToList()
                        group item by item.CategoryId into items
                        orderby items.Count() descending
                        select new 
                        {
                            Category = items.Key,
                            CountBorrow = items.Count(),
                        };
            var reader = query.ToList();
            for (int i = 0; i < reader.Count; i++)
            {
                Category item = await _repositoryCategory.GetAsync(reader[i].Category);
                var categoryResponse = ObjectMapper.Map<Category, CategoryResponse>(item);
                TopCategoryResponse topCategoryResponse = new TopCategoryResponse();
                topCategoryResponse.Category = categoryResponse;
                topCategoryResponse.CountBorrow = reader[i].CountBorrow;
                listResult.Add(topCategoryResponse);
            }
            for (int i = 0; i < listResult.Count; i++)
            {
                var query2 = from p in listBook.Items
                             where p.CategoryBook.Id == listResult[i].Category.Id
                             group p by p.CategoryBook.Id into items
                             select new
                             {
                                 SoLuong = items.Sum(x => x.NumberBook)
                             };
                var reader2 = query2.ToList();
                listResult[i].NumberBookInCategory = reader2[0].SoLuong;
            }
            return listResult;
        }

        [HttpGet]
        public async Task<List<TopCategoryResponse>> GetListCategoryForReaderAsync(Guid IdReader)
        {
            var input = new PagedAndSortedResultRequestDto { MaxResultCount = 1000, SkipCount = 0 };
            PagedResultDto<Category> categories = await _repositoryCategory.GetListAsync(input);
            List<TopCategoryResponse> listResult = new List<TopCategoryResponse>();
            PagedResultDto<Borrow> list = await _repository.GetListAsync(input);
            PagedResultDto<Book> listBook = await _repositoryBook.GetListAsync(input);

            var listBookBorrow = list.Items.Where(w => w.IdReader == IdReader).ToList();
            var query1 = from p in listBookBorrow.ToList()
                         join c in categories.Items on p.BookBorrow.IdCategory equals c.Id
                         select new
                         {
                             BookName = p.BookBorrow.NameBook,
                             CategoryId = c.Id
                         };
            var query = from item in query1.ToList()
                        group item by item.CategoryId into items
                        orderby items.Count() descending
                        select new
                        {
                            Category = items.Key,
                            CountBorrow = items.Count(),
                        };
            var reader = query.ToList();
            for (int i = 0; i < reader.Count; i++)
            {
                Category item = await _repositoryCategory.GetAsync(reader[i].Category);
                var categoryResponse = ObjectMapper.Map<Category, CategoryResponse>(item);
                TopCategoryResponse topCategoryResponse = new TopCategoryResponse();
                topCategoryResponse.Category = categoryResponse;
                topCategoryResponse.CountBorrow = reader[i].CountBorrow;
                listResult.Add(topCategoryResponse);
            }
            return listResult;
        }

        [HttpGet]
        public async Task<List<int>> GetIsReturnBookOnTimeAsync()
        {
            var input = new PagedAndSortedResultRequestDto { MaxResultCount = 1000, SkipCount = 0 };
            PagedResultDto<BorrowResponse> listResultDto = new PagedResultDto<BorrowResponse>();
            var list = this.GetListAsync(input).Result;
            List<int> result = new List<int>();
            DateTime dateTime = DateTime.Now;
            var resultSearch1 = list.Items.Where(x => x.IsReturnBook == false).Where(x => dateTime.Date > x.DateReturn.Date);
            var resultSearch2 = list.Items;
            result.Add(resultSearch1.Count());
            result.Add(resultSearch2.Count() - resultSearch1.Count());
            return result;
        }
    }
}
