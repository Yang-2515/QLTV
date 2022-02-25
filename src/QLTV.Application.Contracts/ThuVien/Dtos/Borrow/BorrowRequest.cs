using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLTV.ThuVien.Dtos.Borrow
{
    public class BorrowRequest
    {
        [Required(ErrorMessage = "Date Borrow is required")]
        [DataType(DataType.Date)]
        public DateTime DateBorrow { get; set; }

        [Required(ErrorMessage = "Date Return is required")]
        [DataType(DataType.Date)]
        public DateTime DateReturn { get; set; }

        //[Required(ErrorMessage = "Please choice")]
        //[Range(typeof(bool), "false", "true")]
        public bool IsReturnBook { get; set; }

        [Required]
        public virtual Guid IdBook { get; set; }

        [Required]
        public virtual Guid IdReader { get; set; }
    }
}
