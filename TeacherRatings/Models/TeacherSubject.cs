using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeacherRatings.Models
{
    public class TeacherSubject
    {
        [Key]
        public int TeacherSubjectId { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }

        [ForeignKey("TeacherId")]
        public virtual Teacher Teacher { get; set; }
        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }

        //Підготовленість викладача та рівень володіння матеріалом 
        //Preparedness teacher and level of material
        //Цікавість викладання матеріалу
        //Interest of teaching
        //Доступність та зрозумілість представлення матеріалу
        //Accessibility and clarity of presentation material
        //Вдалість підбору викладачем прикладів/задач
        //The success teacher recruitment examples / problems
        //Ентузіазм викладача при подачі матеріалу
        //The enthusiasm of the teacher when submitting material
        //Зрозумілість значення дисципліни для моєї спеціальності
        //Clarity importance of discipline for my profession
        //Зрозумілість зв’язку дисципліни з іншими дисциплінами моєї спеціальності
        //Transparency of communication disciplines with other subjects of my specialty
        //Наскільки пари даного викладача підвищують мою кваліфікацію в даній дисципліні
        //How one teacher couples improve my skills in this discipline
        //Ставлення викладача до студентів
        //The ratio of teachers to students
        //Вимогливість викладача
        //Insistence teacher
        //Об’єктивність оцінювання
        //Objectivity assessment
        //Відвідування мною пар з даної дисципліни
        //Visit me in the discipline couples
        

        //Можно добавить оценки
    }
}