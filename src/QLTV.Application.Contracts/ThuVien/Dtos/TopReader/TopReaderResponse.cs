using QLTV.ThuVien.Dtos.Reader;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace QLTV.ThuVien.Dtos.TopReader
{
    public class TopReaderResponse
    {
        public ReaderResponse Reader { get; set; }
        public int CountBorrow { get; set; }
    }
}
