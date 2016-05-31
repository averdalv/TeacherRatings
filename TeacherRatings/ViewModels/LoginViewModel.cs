using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeacherRatings.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Поле Email не може бути порожнім")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Поле Пароль не може бути порожнім")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}