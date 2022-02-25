using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace QLTV.ThuVien
{
    public class Block : FullAuditedAggregateRoot<Guid>
    {
        public string NameBlock { get; set; }
        public int NumberBookInBlock { get; set; }
        public int Capacity { get; set; }

        public int AvailableSpace { get; set; }

        public List<Book> BlockBooks { get; set; }
    }
}
