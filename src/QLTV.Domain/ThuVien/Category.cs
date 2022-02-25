using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace QLTV.ThuVien
{
    public class Category : FullAuditedAggregateRoot<Guid>
    {
        public string NameCategory { get; set; }
        public string DescriptionCategory { get; set; }

        public List<Book> CategoryBooks { get; set; }
    }
}
