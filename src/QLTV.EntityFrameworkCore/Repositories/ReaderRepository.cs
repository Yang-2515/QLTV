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
    public class ReaderRepository : EfCoreRepository<QLTVDbContext, Reader, Guid>,
        IReaderRepository
    {
        public ReaderRepository(IDbContextProvider<QLTVDbContext> dbContextProvider)
            : base(dbContextProvider) { }
        public async Task<PagedResultDto<Reader>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            PagedResultDto<Reader> list = new PagedResultDto<Reader>();
            list.TotalCount = await GetQueryable().Where(w => !w.IsDeleted).CountAsync();
            list.Items = await GetQueryable().Where(w => !w.IsDeleted).OrderByDescending(w => w.CreationTime)
                .ThenByDescending(w => w.LastModificationTime)
                .Skip(input.SkipCount).Take(input.MaxResultCount).AsNoTracking().ToListAsync();
            return list;
        }
    }
}
