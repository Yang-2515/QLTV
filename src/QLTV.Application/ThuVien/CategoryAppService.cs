using Microsoft.AspNetCore.Mvc;

using QLTV.ThuVien.Dtos.Categories;
using QLTV.ThuVien.Dtos.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using QLTV.ThuVien.Services;

namespace QLTV.ThuVien
{
    public class CategoryAppService : CrudAppService<
        Category,
        CategoryResponse,
        Guid,
        PagedAndSortedResultRequestDto,
        CategoryRequest,
        CategoryRequest>,
        ICategoryAppService
    {

        public CategoryAppService(
            IRepository<Category, Guid> repository) : base(repository)
        {
        }

        [HttpGet]
        public async Task<PagedResultDto<CategoryResponse>> SearchAsync(ConditionSearchRequest condition)
        {
            var input = new PagedAndSortedResultRequestDto { MaxResultCount = 1000, SkipCount = 0 };
            if (condition.keyword == null)
            {
                condition.keyword = "";
            }
            PagedResultDto<CategoryResponse> listResultDto = new PagedResultDto<CategoryResponse>();
            var list = this.GetListAsync(input).Result;
            var resultSearch = list.Items.Where(x => x.NameCategory.ToLower().Contains(condition.keyword.ToLower()) || x.DescriptionCategory.ToLower().Contains(condition.keyword.ToLower()) );
            listResultDto.TotalCount = resultSearch.Count();
            listResultDto.Items = resultSearch.Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();
            return listResultDto;
        }
    }
}
