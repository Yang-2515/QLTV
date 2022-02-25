using System;
using QLTV.ThuVien.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;


namespace QLTV.ThuVien
{
    public interface IExampleAppService :
        ICrudAppService< 
            ExampleDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateExampleDto,
            CreateUpdateExampleDto>
    {
        
    }
}