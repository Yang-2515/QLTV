using Microsoft.EntityFrameworkCore;
using QLTV.EntityFrameworkCore;
using QLTV.ThuVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace QLTV.Repositories
{
    public class BookRepository : EfCoreRepository<QLTVDbContext, Book, Guid>,
        IBookRepository
    {
        public BookRepository(IDbContextProvider<QLTVDbContext> dbContextProvider)
            : base(dbContextProvider) { }
        public async Task<PagedResultDto<Book>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            PagedResultDto<Book> list = new PagedResultDto<Book>();
            list.TotalCount = await GetQueryable().Where(w => !w.IsDeleted).CountAsync();
            list.Items = await GetQueryable().Where(w => !w.IsDeleted).Include(t => t.AuthorBook)
                .Include(c => c.CategoryBook)
                .Include(l => l.BlockBook)
                .OrderByDescending(w => w.CreationTime)
                .ThenByDescending(w => w.LastModificationTime)
                .Skip(input.SkipCount).Take(input.MaxResultCount).AsNoTracking().ToListAsync();
            return list;
        }

        public async Task<Book> GetAsync(Guid input)
        {
            Book book = GetQueryable().Where(w => w.Id == input)
                .Include(t => t.AuthorBook)
                .Include(t => t.BlockBook)
                .Include(t => t.CategoryBook)
                .Select(p => p).FirstOrDefault();
            return book;
        }
    }
}
