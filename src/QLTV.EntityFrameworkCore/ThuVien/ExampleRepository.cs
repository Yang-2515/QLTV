using System;
using QLTV.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace QLTV.ThuVien
{
    public class ExampleRepository : EfCoreRepository<QLTVDbContext, Example, Guid>, IExampleRepository
    {
        public ExampleRepository(IDbContextProvider<QLTVDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}