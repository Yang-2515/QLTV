using QLTV.ThuVien.Dtos.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLTV.ThuVien.Dtos.TopCategory
{
    public class TopCategoryResponse
    {
        public CategoryResponse Category { get; set; }
        public int CountBorrow { get; set; }
        public int NumberBookInCategory { get; set; }
    }
}
