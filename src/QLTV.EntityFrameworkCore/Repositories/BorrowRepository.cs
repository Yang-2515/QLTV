using Microsoft.EntityFrameworkCore;
using QLTV.EntityFrameworkCore;
using QLTV.ThuVien;
using QLTV.ThuVien.Dtos.TopReader;
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
    public class BorrowRepository : EfCoreRepository<QLTVDbContext, Borrow, Guid>,
        IBorrowRepository
    {
        public BorrowRepository(IDbContextProvider<QLTVDbContext> dbContextProvider)
            : base(dbContextProvider) 
        {

        }
        public async Task<PagedResultDto<Borrow>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            PagedResultDto<Borrow> list = new PagedResultDto<Borrow>();
            list.TotalCount = await GetQueryable().Where(w => !w.IsDeleted).CountAsync();
            list.Items = await GetQueryable().Where(w => !w.IsDeleted).Include(t => t.BookBorrow)
                .Include(c => c.ReaderBorrow)
                .OrderByDescending(w => w.CreationTime)
                .ThenByDescending(w => w.LastModificationTime)
                .Skip(input.SkipCount).Take(input.MaxResultCount).AsNoTracking().ToListAsync();
            return list;
        }
    }
}
