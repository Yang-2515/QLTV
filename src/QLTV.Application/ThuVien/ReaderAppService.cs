using Microsoft.AspNetCore.Mvc;
using QLTV.Repositories;
using QLTV.Services;
using QLTV.ThuVien.Dtos.Reader;
using QLTV.ThuVien.Search;
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
    public class ReaderAppService :
        CrudAppService<Reader,
            ReaderResponse,
            Guid,
            PagedAndSortedResultRequestDto,
            ReaderRequest,
            ReaderRequest>,
        IReaderAppService
    {
        private readonly IReaderRepository _repositoryReader;

        public ReaderAppService(IReaderRepository Readers, IRepository<Reader,Guid> repository) : base(repository)
        {
            _repositoryReader = Readers;
        }

        [HttpGet]
        public async Task<PagedResultDto<ReaderResponse>> SearchAsync(ConditionSearchRequest condition)
        {

            var input = new PagedAndSortedResultRequestDto { MaxResultCount = 1000, SkipCount = 0 };
            if (condition.keyword == null)
            {
                condition.keyword = "";
            }
            PagedResultDto<ReaderResponse> listResultDto = new PagedResultDto<ReaderResponse>();
            var list = this.GetListAsync(input).Result;
            var resultSearch = list.Items.Where(x => x.NameReader.ToLower().Contains(condition.keyword.ToLower()) 
            || x.Age.ToString().ToLower().Contains(condition.keyword.ToLower())
            || x.Address.ToLower().Contains(condition.keyword.ToLower())
            || x.Phone.ToLower().Contains(condition.keyword.ToLower())
            || x.Email.ToLower().Contains(condition.keyword.ToLower())
            || x.IdCard.ToLower().Contains(condition.keyword.ToLower()));
            listResultDto.TotalCount = resultSearch.Count();
            listResultDto.Items = resultSearch.Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();

            return listResultDto;

        }

        public async Task<bool> CheckExistIdCard(string Id)
        {
            PagedResultDto<Reader> items = await _repositoryReader.GetListAsync(new PagedAndSortedResultRequestDto { MaxResultCount = 1000, SkipCount = 0 });
            foreach(var item in items.Items)
            {
                if(item.IdCard == Id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
