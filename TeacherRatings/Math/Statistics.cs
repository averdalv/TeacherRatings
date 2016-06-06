using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeacherRatings.Models;
using TeacherRatings.HelperClasses;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace TeacherRatings.Math
{
    public class Statistics
    {
        public void Update(CriteriaReturn crRet)
        {
            var context = new DataContext();
            var criteria = (from row in context.TeacherSubjects
                            where (row.TeacherId == crRet.teacherId && row.SubjectId == crRet.subjectId)
                            select row.Criteria).First();
            criteria.Preparedness += crRet.Criterias[0];
            criteria.Interest += crRet.Criterias[1];
            criteria.Accessibility += crRet.Criterias[2];                
            criteria.ClarityImportance += crRet.Criterias[3];           
            criteria.Ratio += crRet.Criterias[4];
            criteria.Insistence += crRet.Criterias[5];
            criteria.ObjectivityAssessment += crRet.Criterias[6];
            criteria.Visit += crRet.Criterias[7];
            criteria.TeacherSubject = (from row in context.TeacherSubjects
                                       where (row.TeacherId == crRet.teacherId && row.SubjectId == crRet.subjectId)
                                       select row).First();
            context.SaveChanges();           

            //int c = criteria.Preparedness.ToList().Count(x => x == '1');
        }
    }
}