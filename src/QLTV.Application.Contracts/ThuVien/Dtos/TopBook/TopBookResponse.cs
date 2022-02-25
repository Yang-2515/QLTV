using QLTV.ThuVien.Dtos.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLTV.ThuVien.Dtos.TopBook
{
    public class TopBookResponse
    {
        public BookResponse Book { get; set; }
        public int CountBorrow { get; set; }
    }
}
