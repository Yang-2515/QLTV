using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace QLTV.ThuVien
{
    public class Example : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string GhiChu { get; set; }

        protected Example()
        {
        }

        public Example(
            Guid id,
            string name,
            string ghiChu
        ) : base(id)
        {
            Name = name;
            GhiChu = ghiChu;
        }
    }
}
