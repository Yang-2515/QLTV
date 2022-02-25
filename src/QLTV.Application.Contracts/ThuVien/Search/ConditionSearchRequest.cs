using System;
using System.Collections.Generic;
using System.Text;

namespace QLTV.ThuVien.Search
{
    public class ConditionSearchRequest
    {
        public string keywordCombobox { get; set; }
        public string keyword { get; set; }
        public int SkipCount { get; set; }
        public int MaxResultCount { get; set; }

    }
}
