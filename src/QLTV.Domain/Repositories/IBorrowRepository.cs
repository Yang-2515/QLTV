using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLTV.ThuVien;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using QLTV.ThuVien.Dtos.TopReader;

namespace QLTV.Repositories
{
    public interface IBorrowRepository: IRepository<Borrow, Guid>, IBasicRepository<Borrow, Guid>
    {
        Task<PagedResultDto<Borrow>> GetListAsync(PagedAndSortedResultRequestDto input);
    }
}
