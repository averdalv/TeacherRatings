using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeacherRatings.Models
{
    public class Evaluation
    {
        [Key]
        public int EvaluationId { get; set; }

        //Критерии
        public int Preparedness { get; set; }
        public int Interest { get; set; }
        public int Accessibility { get; set; }    
        public int ClarityImportance { get; set; }     
        public int Ratio { get; set; }
        public int Insistence { get; set; }
        public int ObjectivityAssessment { get; set; }
        public int Visit { get; set; }
        public virtual ICollection<TeacherUser> TeacherUsers { get; set; }
        public Evaluation()
        {
            this.TeacherUsers = new HashSet<TeacherUser>();
        }
    }
}