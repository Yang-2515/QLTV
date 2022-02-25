using Microsoft.AspNetCore.Mvc;
using QLTV.Repositories;
using QLTV.Services;
using QLTV.ThuVien.Dtos.Block;
using QLTV.ThuVien.Dtos.Books;
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

    public class BlockAppService :
        CrudAppService<
            Block,
            BlockResponse,
            Guid,
            PagedAndSortedResultRequestDto,
            BlockRequest,
            BlockRequest>,
        IBlockAppService
    {
        private readonly IBlockRepository _repository;
        private readonly IBookRepository _bookrepository;
        public BlockAppService(IBlockRepository repository, IBookRepository bookrepository) : base(repository)
        {
            _bookrepository = bookrepository;
            _repository = repository;
        }

       

        [HttpGet]
        public async Task<PagedResultDto<BlockResponse>> SearchAsync(ConditionSearchRequest condition)
        {

            var input = new PagedAndSortedResultRequestDto { MaxResultCount = 1000, SkipCount = 0 };
            if (condition.keyword == null)
            {
                condition.keyword = "";
            }
            PagedResultDto<BlockResponse> listResultDto = new PagedResultDto<BlockResponse>();
            var list = this.GetListAsync(input).Result;
            var resultSearch = list.Items.Where(x => x.NameBlock.ToLower().Contains(condition.keyword.ToLower()) 
            ||  x.NumberBookInBlock.ToString().Contains(condition.keyword.ToLower())
            || x.Capacity.ToString().Contains(condition.keyword.ToLower())
            || x.AvailableSpace.ToString().Contains(condition.keyword.ToLower())
            );
            listResultDto.TotalCount = resultSearch.Count();
            listResultDto.Items = resultSearch.Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();

            return listResultDto;

        }

        [HttpGet]
        public async Task<PagedResultDto<BlockResponse>> GetIsNumberInBlockAsync(ConditionSearchRequest condition)
        {
            var input = new PagedAndSortedResultRequestDto { MaxResultCount = 1000, SkipCount = 0 };
            PagedResultDto<BlockResponse> listResultDto = new PagedResultDto<BlockResponse>();
            var list = this.SearchAsync(new ConditionSearchRequest { keyword = condition.keyword, MaxResultCount = 1000, SkipCount = 0 }).Result;
            listResultDto.TotalCount = 0;
            listResultDto.Items = null;
            if(condition.keywordCombobox.Equals("none"))
            {
                var resultSearch = list.Items;
                listResultDto.TotalCount = resultSearch.Count();
                listResultDto.Items = resultSearch.Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();

            }
            else
            {
                if (condition.keywordCombobox.Equals("chua_co_sach"))
                {
                    var resultSearch = list.Items.Where(x => x.NumberBookInBlock.Equals(0));
                    listResultDto.TotalCount = resultSearch.Count();
                    listResultDto.Items = resultSearch.Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();
                }
                else
                {
                    if (condition.keywordCombobox.Contains("da_day"))
                    {
                        var resultSearch = list.Items.Where(x => x.NumberBookInBlock.Equals(x.Capacity));
                        listResultDto.TotalCount = resultSearch.Count();
                        listResultDto.Items = resultSearch.Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();
                    }
                    else
                    {
                        var resultSearch = list.Items.Where(x => x.NumberBookInBlock.IsBetween(1, x.Capacity - 1));
                        listResultDto.TotalCount = resultSearch.Count();
                        listResultDto.Items = resultSearch.Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();
                    }
                }
            }
            
            return listResultDto;
        }
        public async Task ChangeSpace(Guid idBook, int i)
        {
            var book = _bookrepository.GetAsync(idBook);
            var input = new PagedAndSortedResultRequestDto { MaxResultCount = 1000, SkipCount = 0 };
            var list = this.GetListAsync(input).Result;
            var result = list.Items.Where(w => w.NameBlock == book.Result.BlockBook.NameBlock).FirstOrDefault();
            result.AvailableSpace += i;
            if (result != null)
            {
                await this.UpdateAsync(result.Id, ObjectMapper.Map<BlockResponse, BlockRequest>(result));
            }
        }
        public async Task<PagedResultDto<BlockResponse>> GetListEmptyBlock()
        {
            var input = new PagedAndSortedResultRequestDto { MaxResultCount = 1000, SkipCount = 0 };
            var list = await this.GetListAsync(input);
            var result = list.Items.Where(w => w.AvailableSpace > 0).ToList();
            PagedResultDto<BlockResponse> listResultDto = new PagedResultDto<BlockResponse>();
            listResultDto.TotalCount = result.Count();
            listResultDto.Items = result.Take(input.MaxResultCount).ToList();

            return listResultDto;
        }
        public async Task ChangeSpaceAndNumberBookInBlock(Guid idBlock, int i)
        {
            var input = new PagedAndSortedResultRequestDto { MaxResultCount = 1000, SkipCount = 0 };
            var list = this.GetListAsync(input).Result;
            var result = list.Items.Where(w => w.Id == idBlock).FirstOrDefault();
            result.AvailableSpace -= i;
            result.NumberBookInBlock += i;
            if (result != null)
            {
                await this.UpdateAsync(result.Id, ObjectMapper.Map<BlockResponse, BlockRequest>(result));
            }
        }
        public async Task<bool> CheckEnoughSpaces(string blockid, int addingbooks)
        {
            List<Block> blocklist = new List<Block>();
            blocklist = await Repository.GetListAsync();
            foreach(var block in blocklist)
            {
                if (block.Id.ToString() == blockid)
                {
                    if ((block.Capacity - block.NumberBookInBlock) >= addingbooks)
                        return true;
                }
            }
            return false;
        }

        public async Task<bool> CheckExistNameBlock(string NameBlock)
        {
            PagedResultDto<Block> items = await _repository.GetListAsync(new PagedAndSortedResultRequestDto { MaxResultCount=100, SkipCount=0});
            foreach(var item in items.Items)
            {
                if(item.NameBlock == NameBlock)
                {
                    return true;
                }
            }
            return false;
        }

        
    }
}
