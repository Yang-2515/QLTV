using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace QLTV.ThuVien
{
    public class Borrow : FullAuditedAggregateRoot<Guid>
    {
        public DateTime DateBorrow { get; set; }
        public DateTime DateReturn { get; set; }
        public bool IsReturnBook { get; set; }

        public Guid IdBook { get; set; }
        public Book BookBorrow { get; set; }

        public Guid IdReader { get; set; }
        public Reader ReaderBorrow { get; set; }
    }
}
