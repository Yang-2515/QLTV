using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace QLTV.ThuVien
{
    public class Reader : FullAuditedAggregateRoot<Guid>
    {
        public string NameReader { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string IdCard { get; set; }

        public List<Borrow> ReaderBorrows { get; set; }
    }
}
