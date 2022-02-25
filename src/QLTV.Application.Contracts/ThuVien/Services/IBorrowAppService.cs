using QLTV.ThuVien.Dtos.Borrow;
using QLTV.ThuVien.Dtos.TopBook;
using QLTV.ThuVien.Dtos.TopCategory;
using QLTV.ThuVien.Dtos.TopReader;
using QLTV.ThuVien.Search;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
namespace QLTV.ThuVien.Services
{
    public interface IBorrowAppService :
        ICrudAppService<
            BorrowResponse,
            Guid,
            PagedAndSortedResultRequestDto,
            BorrowRequest,
            BorrowRequest>
    {
        /// <summary>
        /// Tìm kiếm mượn sách
        /// </summary>
        /// <param name="condition">điều kiện search</param>
        /// <returns></returns>
        Task<PagedResultDto<BorrowResponse>> SearchAsync(ConditionSearchRequest condition);
        
        /// <summary>
        /// Top đọc giả mượn sách
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        Task<PagedResultDto<TopReaderResponse>> GetListTopReaderAsync(ConditionSearchRequest condition);

        /// <summary>
        /// Top sách được mượn nhiều nhất
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        Task<PagedResultDto<TopBookResponse>> GetListTopBookAsync(ConditionSearchRequest condition);

        /// <summary>
        /// Tìm kiếm sách đã trả/ chưa trả
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        Task<PagedResultDto<BorrowResponse>> GetIsReturnBookAsync(ConditionSearchRequest condition);

        /// <summary>
        /// Top thể loại được yêu thích
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        Task<List<TopCategoryResponse>> GetListTopCategoryAsync();

        /// <summary>
        /// Phân theo thể loại cho mỗi người đọc
        /// </summary>
        /// <returns></returns>
        Task<List<TopCategoryResponse>> GetListCategoryForReaderAsync(Guid IdReader);

        /// <summary>
        /// Tìm xem có bao nhiêu quyển trả đúng hạn/ chưa trả đúng hạn
        /// </summary>
        /// <returns></returns>
        Task<List<int>> GetIsReturnBookOnTimeAsync();
    }
}
