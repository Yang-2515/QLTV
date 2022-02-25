using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace QLTV.ThuVien.Dtos.Books
{
    public class BookResponse : EntityDto<Guid>
    {
        public string NameBook { get; set; }
        public DateTime DatePublish { get; set; }
        public double Price { get; set; }
        public int NumberBook { get; set; }
        public string CategoryBook { get; set; }
        public string AuthorBook { get; set; }
        public string BlockBook { get; set; }
        public string IdCategory { get; set; }
        public string IdAuthor { get; set; }
        public string IdBlock { get; set; }
    }
}
