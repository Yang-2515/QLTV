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
    public interface IBookRepository: IRepository<Book, Guid>, IBasicRepository<Book,Guid>
    {
        Task<PagedResultDto<Book>> GetListAsync(PagedAndSortedResultRequestDto input);
        Task<Book> GetAsync(Guid input);
    }
}
