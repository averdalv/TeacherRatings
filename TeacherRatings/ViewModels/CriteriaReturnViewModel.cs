using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherRatings.ViewModels
{
    public class CriteriaReturnViewModel
    {
        public CriteriaReturnViewModel()
        {
            Criterias = new List<string>();
            for (int i = 0; i < 8; ++i) Criterias.Add(string.Empty);
            SubjectId = string.Empty;
            UserId = string.Empty;
        }
        public string TeacherId{ get; set; }
        public string UserId { get; set; }
        public List<string> Criterias { get; set; }
        public string SubjectId { get; set; }
    }
}