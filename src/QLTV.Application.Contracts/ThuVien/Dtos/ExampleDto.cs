using System;
using Volo.Abp.Application.Dtos;

namespace QLTV.ThuVien.Dtos
{
    [Serializable]
    public class ExampleDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string GhiChu { get; set; }
    }
}