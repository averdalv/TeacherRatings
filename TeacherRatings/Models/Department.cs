using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeacherRatings.Models
{
    public class Department  //кафедра
    {
        public Department()
        {
            this.Teachers = new HashSet<Teacher>();
        }
        public int DepartmentId { get; set; }
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }
        [MaxLength(40)]
        public string Abbreviation { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }

    }
}