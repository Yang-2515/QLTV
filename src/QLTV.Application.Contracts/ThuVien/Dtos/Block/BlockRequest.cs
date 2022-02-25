using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLTV.ThuVien.Dtos.Block
{
    public class BlockRequest
    { 
        [Required(ErrorMessage = "Required_NameBlock")]
        [StringLength(20)]
        [Display(Name = "NameBlock", Prompt = "Placeholder_NameBlock")]
        public string NameBlock { get; set; }

        [Required(ErrorMessage = "Required_NumberBook")]
        [Display(Name = "NumberBookInBlock", Prompt = "Placeholder_NumberBook")]
        [Range(0, int.MaxValue, ErrorMessage = "Error_NumberBook")]
        public int NumberBookInBlock { get; set; }

        [Required(ErrorMessage = "Required_Capacity")]
        [Display(Name = "Capacity", Prompt = "Placeholder_Capacity")]
        [Range(0, int.MaxValue, ErrorMessage = "Error_Capacity")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Required_Space")]
        [Display(Name = "AvailableSpace", Prompt = "Placeholder_Space")]
        [Range(0, int.MaxValue, ErrorMessage = "Error_Space")]
        public int AvailableSpace { get; set; }
    }
}
