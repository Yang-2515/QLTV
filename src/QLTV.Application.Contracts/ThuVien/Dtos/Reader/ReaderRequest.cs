using QLTV.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace QLTV.ThuVien.Dtos.Reader
{
    public class ReaderRequest
    { 
        [Required(ErrorMessage = "Reader Name is required")]
        [StringLength(100)]
        [Display(Name = "NameReader", Prompt = "Enter name ...")]
        public string NameReader { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Display(Name = "Age", Prompt = "Enter age ...")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(255)]
        [Display(Name = "Address", Prompt = "Enter address ...")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0]{1})\)?[-. ]?([0-9]{9})$")]
        [Display(Name = "Phone", Prompt = "Enter number ...")]
        public string Phone { get; set; }

        [StringLength(50)]
        [Display(Name = "Email", Prompt = "Enter email ...")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[_A-Za-z0-9-\+]+(\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\.[A-Za-z0-9]+)*(\.[A-Za-z]{2,})$")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Id Card is required")]
        [StringLength(20)]
        [Display(Name = "IdCard", Prompt = "Enter id ...")]
        public string IdCard { get; set; }

    }
}
