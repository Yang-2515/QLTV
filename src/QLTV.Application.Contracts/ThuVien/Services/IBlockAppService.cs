using QLTV.ThuVien.Dtos.Block;
using QLTV.ThuVien.Search;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace QLTV.Services
{
    public interface IBlockAppService :
        ICrudAppService<
            BlockResponse,
            Guid,
            PagedAndSortedResultRequestDto,
            BlockRequest,
            BlockRequest>
    {
        /// <summary>
        /// Tìm kiếm block
        /// </summary>
        /// <param name="condition">điều kiện search</param>
        /// <returns></returns>
        Task<PagedResultDto<BlockResponse>> SearchAsync(ConditionSearchRequest condition);
        /// <summary>
        /// Tìm kiếm block còn trống/ đã đầy/ chưa có sách
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        Task<PagedResultDto<BlockResponse>> GetIsNumberInBlockAsync(ConditionSearchRequest condition);
        /// <summary>
        /// Thay đổi chỗ trống trong block khi trả/mượn sách
        /// </summary>
        /// <param name="idBook"></param>
        /// <param name="i"></param>
        Task ChangeSpace(Guid idBook, int i);
        /// <summary>
        /// List block còn trống
        /// </summary>
        /// <param name="pagedAndSortedResultRequestDto"></param>
        /// <returns></returns>
        Task<PagedResultDto<BlockResponse>> GetListEmptyBlock();
        /// <summary>
        /// Thay đổi chỗ trống và sách trong block khi thêm mới hay thay đổi số lượng sách
        /// </summary>
        /// <param name="idBook"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        Task ChangeSpaceAndNumberBookInBlock(Guid idBlock, int i);

        /// <summary>
        /// Kiểm tra tên Block khi thêm mới Block để tránh trường hợp trùng tên
        /// </summary>
        /// <param name="NameBlock"></param>
        /// <returns></returns>
        Task<bool> CheckExistNameBlock(string  NameBlock);
    }
}
