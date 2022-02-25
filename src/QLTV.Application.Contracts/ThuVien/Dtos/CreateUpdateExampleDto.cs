using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using QLTV.ThuVien;
namespace QLTV.ThuVien.Dtos
{
    [Serializable]
    public class CreateUpdateExampleDto : IValidatableObject
    {
        [Display(Name = "ExampleName")]
        public string Name { get; set; }

        [Display(Name = "ExampleGhiChu")]
        public string GhiChu { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Name == GhiChu)
            {
                yield return new ValidationResult(
                    "Name and GhiChu can not be the same!"
                );
            }
        }
    }
}