using QLTV.ThuVien.Dtos.Books;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using QLTV.ThuVien.Dtos.Search;
using QLTV.ThuVien.Search;

namespace QLTV.Services
{
    public interface IBookAppService : ICrudAppService<
        BookResponse,
        Guid,
        PagedAndSortedResultRequestDto,
        BookRequest,
        BookRequest>
    {
        Task<PagedResultDto<BookResponse>> SearchAsync(ThuVien.Dtos.Search.ConditionSearchRequest condition);

        Task<PagedResultDto<BookResponse>> AdvancedSearchAsync(AdvancedSearch condition);
        /// <summary>
        /// Thay đổi số lượng sách
        /// </summary>
        /// <param name="idBook"></param>
        /// <param name="i"></param>
        Task ChangeNumberBook(Guid idBook, int i);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idBook"></param>
        /// <returns></returns>
        Task ChangeNumberBookForDelete(Guid idBook);
    }
}
