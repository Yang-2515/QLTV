using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace QLTV.Web.Pages.ThuVien.Category.ViewModels
{
    public class CreateEditCategoryViewModel
    {
        [Required(ErrorMessage = "Category Name is required")]
        [StringLength(100)]
        [Display(Name = "CategoryName", Prompt = "Enter name ...")]
        public string NameCategory { get; set; }

        [Required(ErrorMessage = "Category Description is required")]
        [Display(Name = "CategoryDescription", Prompt = "Enter description ...")]
        [StringLength(1000)]
        [TextArea(Rows = 10)]
        public string DescriptionCategory { get; set; }
    }
}
