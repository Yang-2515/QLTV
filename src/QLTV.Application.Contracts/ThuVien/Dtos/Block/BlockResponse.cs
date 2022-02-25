using System;
using Volo.Abp.Application.Dtos;

namespace QLTV.ThuVien.Dtos.Block
{
    public class BlockResponse :EntityDto<Guid>
    {
        public string NameBlock { get; set; }
        public int NumberBookInBlock { get; set; }
        public int Capacity { get; set; }
        public int AvailableSpace { get; set; }
    }
}
