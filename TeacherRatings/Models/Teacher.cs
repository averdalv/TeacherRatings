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
        }
        public int TeacherId { get; set; }

        [Required] 
        [MaxLength(300)]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        public string LastName { get; set; }
        public string Image { get; set; }

        public virtual Department Department{get;set;}
        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }


    }
}