using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeacherRatings.Models
{
    public class Subject
    {
        public Subject()
        {
            this.TeacherSubjects = new HashSet<TeacherSubject>();
            this.Evaluations = new HashSet<Evaluation>();
        }
        public int SubjectId { get; set; }
        [Required]
        [MaxLength(300)]
        public string Name { get; set; }
        public virtual ICollection<TeacherSubject> TeacherSubjects{get;set;}
        public virtual ICollection<Evaluation> Evaluations { get; set; }
        
    }
}