using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLTV.ThuVien;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace QLTV.Repositories
{
    public interface IReaderRepository: IRepository<Reader, Guid>
    {
        Task<PagedResultDto<Reader>> GetListAsync(PagedAndSortedResultRequestDto input);
    }
}
