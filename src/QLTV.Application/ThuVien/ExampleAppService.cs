using System;
using QLTV.Permissions;
using QLTV.ThuVien.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace QLTV.ThuVien
{
    public class ExampleAppService : CrudAppService<Example, ExampleDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateExampleDto, CreateUpdateExampleDto>,
        IExampleAppService
    {
        protected override string GetPolicyName { get; set; } = QLTVPermissions.Example.Default;
        protected override string GetListPolicyName { get; set; } = QLTVPermissions.Example.Default;
        protected override string CreatePolicyName { get; set; } = QLTVPermissions.Example.Create;
        protected override string UpdatePolicyName { get; set; } = QLTVPermissions.Example.Update;
        protected override string DeletePolicyName { get; set; } = QLTVPermissions.Example.Delete;

        private readonly IExampleRepository _repository;
        
        public ExampleAppService(IExampleRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
