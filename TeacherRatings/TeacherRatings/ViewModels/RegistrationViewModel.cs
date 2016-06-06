using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeacherRatings.ViewModels
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Поле Email не може бути порожнім")]
        
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некоректна адреса")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Поле Дата народження не може бути порожнім")]
        
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Довжина поля має бути від 3 до 50 символів")]
        public string City { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Довжина поля має бути від 3 до 50 символів")]
         public string Name { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Довжина поля має бути від 3 до 50 символів")]
         public string LastName { get; set; }
        [Required(ErrorMessage = "Поле Пароль не може бути порожнім")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Підтвердіть пароль")]
        [Compare("Password", ErrorMessage = "Пароли не збігаються")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}