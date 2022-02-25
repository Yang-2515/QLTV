using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace QLTV.ThuVien.Dtos.Author
{
    public class AuthorResponse : EntityDto<Guid>
    {
        public string NameAuthor { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DescriptionAuthor { get; set; }
        
    }
}
