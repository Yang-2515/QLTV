using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace QLTV.ThuVien
{
    public class Book : FullAuditedAggregateRoot<Guid>
    {
        public string NameBook { get; set; }
        public DateTime DatePublish { get; set; }
        public double Price { get; set; }
        public int NumberBook { get; set; }

        public List<Borrow> BookBorrows { get; set; }

        public Guid IdCategory { get; set; }
        public Category CategoryBook { get; set; }

        public Guid IdAuthor { get; set; }
        public Author AuthorBook { get; set; }

        public Guid IdBlock { get; set; }
        public Block BlockBook { get; set; }
    }
}
