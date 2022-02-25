using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace QLTV.ThuVien.Dtos.Categories

{
    public class CategoryResponse : EntityDto<Guid>
    {
        public string NameCategory { get; set; }
        public string DescriptionCategory { get; set; }

    }
}
