using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace QLTV.Web.Pages.ThuVien.Author.ViewModels
{
    public class CreateEditAuthorViewModel
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
        [TextArea(Rows = 10)]
        [Display(Name = "Author Description", Prompt = "Enter description ...")]
        public string DescriptionAuthor { get; set; }
    }
}
