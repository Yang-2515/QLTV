using System;

using System.ComponentModel.DataAnnotations;

namespace QLTV.Web.Pages.ThuVien.Example.ViewModels
{
    public class CreateEditExampleViewModel
    {
        [Display(Name = "ExampleName")]
        public string Name { get; set; }

        [Display(Name = "ExampleGhiChu")]
        public string GhiChu { get; set; }
    }
}