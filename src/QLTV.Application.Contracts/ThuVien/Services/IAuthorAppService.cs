using QLTV.ThuVien.Dtos.Author;
using QLTV.ThuVien.Search;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace QLTV.ThuVien.Services
{
    public interface IAuthorAppService : 
        ICrudAppService<
            AuthorResponse,
            Guid,
            PagedAndSortedResultRequestDto,
            AuthorRequest,
            AuthorRequest>
    {
        /// <summary>
        /// Tìm kiếm tác giả
        /// </summary>
        /// <param name="condition">điều kiện search</param>
        /// <returns></returns>
        Task<PagedResultDto<AuthorResponse>> SearchAsync(ConditionSearchRequest condition);
    }

}
