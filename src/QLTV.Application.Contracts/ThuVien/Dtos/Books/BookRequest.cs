using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using QLTV.ThuVien;


namespace QLTV.ThuVien.Dtos.Books
{
    public class BookRequest
    {
        [Required(ErrorMessage = "Book Name is required")]
        [Display(Name = "Book Name", Prompt = "Enter name ...")]
        [StringLength(100)]
        public string NameBook { get; set; }

        [Required(ErrorMessage = "Publish Date is required")]
        [Display(Name = "Publish Date", Prompt = "EnterPublishDate")]
        [DataType(DataType.Date)]
        public DateTime DatePublish { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Price", Prompt = "EnterPrice")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [Required(ErrorMessage = "Number Book is required")]
        [Display(Name = "Number Book", Prompt = "EnterNumberBook")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer")]
        public int NumberBook { get; set; }

        [Required]
        public virtual Guid IdCategory { get; set; }

        [Required]
        public virtual Guid IdAuthor { get; set; }

        [Required]
        public virtual Guid IdBlock { get; set; }
    }
}
