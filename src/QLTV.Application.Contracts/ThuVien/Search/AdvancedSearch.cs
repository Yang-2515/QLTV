using System;
using System.Collections.Generic;
using System.Text;

namespace QLTV.ThuVien.Search
{
    public class AdvancedSearch
    {
        public string? keyword { get; set; }

        public string? category { get; set; }
        public int SkipCount { get; set; }
        public int MaxResultCount { get; set; }

        

        public long? minPrice { get; set; }
        public long? maxPrice { get; set; }
    }
}
