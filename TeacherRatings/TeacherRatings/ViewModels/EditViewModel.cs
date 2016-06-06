using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeacherRatings.ViewModels
{
    public class EditViewModel
    {
        [Required]
        
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Довжина поля не може бути більшою ніж 50")]
        public string City { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Довжина поля не може бути більшою ніж 50")]
        public string Name { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Довжина поля не може бути більшою ніж 50")]
        public string LastName { get; set; }
    }
}