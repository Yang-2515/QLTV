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
    public interface IBlockRepository: IRepository<Block, Guid>
    {
        Task<PagedResultDto<Block>> GetListAsync(PagedAndSortedResultRequestDto input);
    }
}
