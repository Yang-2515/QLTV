using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using QLTV.ThuVien.Dtos.Categories;
using QLTV.ThuVien.Dtos.Books;
using QLTV.ThuVien.Dtos.Search;

namespace QLTV.ThuVien.Services
{
    public interface ICategoryAppService : ICrudAppService<
        CategoryResponse,
        Guid,
        PagedAndSortedResultRequestDto,
        CategoryRequest,
        CategoryRequest>
    {
        Task<PagedResultDto<CategoryResponse>> SearchAsync(ConditionSearchRequest condition);
    }
}
