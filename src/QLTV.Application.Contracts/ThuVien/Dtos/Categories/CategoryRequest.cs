using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.Extensions.Localization;
using QLTV.Localization;
using Volo.Abp.Localization;

namespace QLTV.ThuVien.Dtos.Categories
{
    
    public class CategoryRequest
    {

        [Required(ErrorMessage = "Category Name is required")]
        [StringLength(100)]
        [Display(Name="CategoryName" ,Prompt = "Enter name ...")]
        public string NameCategory { get; set; }

        [Required(ErrorMessage = "Category Description is required")]
        [Display(Name = "CategoryDescription", Prompt = "Enter description ...")]
        [StringLength(1000)]
        
        public string DescriptionCategory { get; set; }

        

    }
    
}
