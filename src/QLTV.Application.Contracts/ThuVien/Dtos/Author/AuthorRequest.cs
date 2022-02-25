using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLTV.ThuVien.Dtos.Author
{
    public class AuthorRequest
    {
        [Required(ErrorMessage = "Author Name is required")]
        [StringLength(100)]
        [Display(Name = "Author Name", Prompt = "Enter name ...")]
        public string NameAuthor { get; set; }

        [Required(ErrorMessage = "Date Of Birth is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Author Description is required")]
        [StringLength(255)]
        [Display(Name = "Author Description", Prompt = "Enter description ...")]
        public string DescriptionAuthor { get; set; }


    }
}
