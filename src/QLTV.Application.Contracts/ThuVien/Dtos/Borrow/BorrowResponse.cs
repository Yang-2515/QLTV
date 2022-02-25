using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace QLTV.ThuVien.Dtos.Borrow
{
    public class BorrowResponse : EntityDto<Guid>
    {
        public DateTime DateBorrow { get; set; }
        public DateTime DateReturn { get; set; }
        public bool IsReturnBook { get; set; }
        public string BookBorrow { get; set; }
        public string ReaderBorrow { get; set; }
        public string IdBook { get; set; }
        public string IdReader { get; set; }
    }
}
