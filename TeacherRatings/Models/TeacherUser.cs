using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeacherRatings.Models
{
    public class TeacherUser
    {
        [Key]
        public int TeacherUserId { get; set; }
        public int TeacherId { get; set; }
        public string UserId { get; set; }
        public int EvaluationId { get; set; }

        [ForeignKey("TeacherId")]
        public virtual Teacher Teacher { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User{ get; set; }
        [ForeignKey("EvaluationId")]
        public virtual Evaluation Evaluation { get; set; }
       
    }
}