using QLTV.EntityFrameworkCore;
using QLTV.ThuVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using QLTV.Repositories;
using Volo.Abp.Application.Dtos;
using Volo.Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace QLTV.Repositories
{
    public class AuthorRepository : EfCoreRepository<QLTVDbContext, Author, Guid>,
        IAuthorRepository
    {
        public AuthorRepository(IDbContextProvider<QLTVDbContext> dbContextProvider)
            : base(dbContextProvider) { }
        public async Task<PagedResultDto<Author>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            PagedResultDto<Author> list = new PagedResultDto<Author>();
            list.TotalCount = await GetQueryable().Where(w => !w.IsDeleted).CountAsync();
            list.Items = await GetQueryable().Where(w => !w.IsDeleted).OrderByDescending(w => w.CreationTime)
                .ThenByDescending(w => w.LastModificationTime)
                .Skip(input.SkipCount).Take(input.MaxResultCount).AsNoTracking().ToListAsync();
            return list;
        }
    }
}
