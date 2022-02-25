using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace QLTV.ThuVien.Dtos.Reader
{
    public class ReaderResponse : EntityDto<Guid>
    {
        public string NameReader { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string IdCard { get; set; }
    }
}
