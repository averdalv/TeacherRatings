using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherRatings.HelperClasses
{
    public class CriteriaReturn
    {
        public CriteriaReturn()
        {
            Criterias = new List<string>();
            for (int i = 0; i < 8; ++i) Criterias.Add(string.Empty);
        }
        public int teacherId{ get; set; }
        public int subjectId{ get; set; }
        public List<string> Criterias { get; set; }
    }
}