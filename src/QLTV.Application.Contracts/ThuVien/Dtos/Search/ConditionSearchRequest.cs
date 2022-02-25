using System;
using System.Collections.Generic;
using System.Text;

namespace QLTV.ThuVien.Dtos.Search
{
    public class ConditionSearchRequest
    {
        public string keyword { get; set; }
        public int SkipCount { get; set; }
        public int MaxResultCount { get; set; }
    }
}
