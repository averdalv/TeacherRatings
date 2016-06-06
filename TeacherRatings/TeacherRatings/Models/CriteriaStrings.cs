using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeacherRatings.Models
{
    public class CriteriaStrings
    {
        [Key]
        public int CriteriaStringsId { get; set; }
        public string CriteriaText { get; set; }
        public string CriteriaName { get; set; }
    }
}