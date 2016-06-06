using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeacherRatings.Models
{
    public class Teacher
    {
        public Teacher()
        {
            this.TeacherSubjects=new HashSet<TeacherSubject>();
            this.TeacherUsers = new HashSet<TeacherUser>();
        }
        public int TeacherId { get; set; }

        [Required] 
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [MaxLength(40)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(40)]
        public string Patronymic { get; set; }
        public string Image { get; set; }
        [MaxLength(4000)]
        public string Information { get; set; }

        public virtual Department Department{get;set;}
        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
        public virtual ICollection<TeacherUser> TeacherUsers { get; set; }


    }
}