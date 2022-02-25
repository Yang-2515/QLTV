using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace QLTV.ThuVien
{
    public class Author : FullAuditedAggregateRoot<Guid>
    {
        public string NameAuthor { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DescriptionAuthor { get; set; }

        public List<Book> AuthorBooks { get; set; }
    }
}
