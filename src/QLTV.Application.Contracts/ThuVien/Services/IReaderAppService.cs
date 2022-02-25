using QLTV.ThuVien.Dtos.Reader;
using QLTV.ThuVien.Search;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace QLTV.Services
{
    public interface IReaderAppService :
        ICrudAppService<
            ReaderResponse,
            Guid,
            PagedAndSortedResultRequestDto,
            ReaderRequest,
            ReaderRequest>
    {
        /// <summary>
        /// tìm kiếm reader
        /// </summary>
        /// <param name="condition">điều kiện search</param>
        /// <returns></returns>
        Task<PagedResultDto<ReaderResponse>> SearchAsync(ConditionSearchRequest condition);

        /// <summary>
        /// Check xem có Id trong cơ sở dữ liệu hay ko
        /// </summary>
        /// <param name="Id">Id dùng để check</param>
        /// <returns>true => có, false => không</returns>
        Task<bool> CheckExistIdCard(string Id);
    }
}
