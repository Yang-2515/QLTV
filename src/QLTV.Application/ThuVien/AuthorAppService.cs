using Microsoft.AspNetCore.Mvc;
using QLTV.ThuVien.Dtos.Author;
using QLTV.ThuVien.Search;
using QLTV.ThuVien.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace QLTV.ThuVien
{
    public class AuthorAppService :
        CrudAppService<Author,
            AuthorResponse, Guid, PagedAndSortedResultRequestDto,
            AuthorRequest, AuthorRequest>,
        IAuthorAppService
    {
        public AuthorAppService(IRepository<Author, Guid> repository) : base(repository)
        {

        }

        [HttpGet]
        public async Task<PagedResultDto<AuthorResponse>> SearchAsync(ConditionSearchRequest condition)
        {
            var input = new PagedAndSortedResultRequestDto { MaxResultCount = 1000, SkipCount = 0 };
            if (condition.keyword == null)
            {
                condition.keyword = "";
            }

            PagedResultDto<AuthorResponse> listResultDto = new PagedResultDto<AuthorResponse>();
            var list = this.GetListAsync(input).Result;
            var resultSearch = list.Items.Where(x => x.NameAuthor.ToLower().Contains(condition.keyword.ToLower()) || x.DescriptionAuthor.ToLower().Contains(condition.keyword.ToLower()) );
            listResultDto.TotalCount = resultSearch.Count();
            listResultDto.Items = resultSearch.Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();
            return listResultDto;
        }


    }
}
