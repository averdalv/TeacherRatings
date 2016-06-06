using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeacherRatings.Models
{
    public class Criteria
    {
        [Key]
        public int CriteriaId { get; set; }

        //Критерии
        public string Preparedness { get; set; }
        public string Interest { get; set; }
        public string Accessibility { get; set; }
       // public string Examples { get; set; }
      //  public string Enthusiasm { get; set; }
        public string ClarityImportance { get; set; }
     //   public string CommunicationDisciplines { get; set; }
       // public string ImproveMySkills { get; set; }
        public string Ratio { get; set; }
        public string Insistence { get; set; }
        public string ObjectivityAssessment { get; set; }
        public string Visit { get; set; }
        //--------
        [Required]
        public virtual TeacherSubject TeacherSubject { get; set; }



        //Підготовленість викладача та рівень володіння матеріалом 
        //Preparedness
        //Цікавість викладання матеріалу
        //Interest
        //Доступність та зрозумілість представлення матеріалу
        //Accessibility
        //Вдалість підбору викладачем прикладів/задач
        //Examples
        //Ентузіазм викладача при подачі матеріалу
        //Enthusiasm
        //Зрозумілість значення дисципліни для моєї спеціальності
        //ClarityImportance
        //Зрозумілість зв’язку дисципліни з іншими дисциплінами моєї спеціальності
        //CommunicationDisciplines
        //Наскільки пари даного викладача підвищують мою кваліфікацію в даній дисципліні
        //ImproveMySkills
        //Ставлення викладача до студентів
        //Ratio
        //Вимогливість викладача
        //Insistence
        //Об’єктивність оцінювання
        //ObjectivityAssessment
        //Відвідування мною пар з даної дисципліни
        //Visit
    }
}