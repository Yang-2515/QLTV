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
    public interface IAuthorRepository: IRepository<Author, Guid>
    {
        Task<PagedResultDto<Author>> GetListAsync(PagedAndSortedResultRequestDto input);
    }
}
