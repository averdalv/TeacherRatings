using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherRatings.Models
{
    public class ApplicationRole : IdentityRole   //Клас ролей (админ,пользователь и тд)
    {
        public ApplicationRole() { }

        public string Description { get; set; }
    }
}