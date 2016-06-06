using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherRatings.Models
{
    public class ApplicationUser:IdentityUser //Клас пользователей
    {
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<TeacherUser> TeacherUsers { get; set; }
        public ApplicationUser()
        {
            this.TeacherUsers = new HashSet<TeacherUser>();
        }
    }
}