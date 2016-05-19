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
        [MaxLength(300)]
        public string Name { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }

    }
}