using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Note : BaseEntity
    {
        public double Exam1 { get; set; }
        public double Exam2 { get; set; }
        public double Exam3 { get; set; }
        public double Project { get; set; }
        public int Avarage { get; set; }
        public bool Case { get; set; }

        public int? StudentID { get; set; }
        public int? LessonID{ get; set; }

        //Relational Properties

        public virtual Student Student { get; set; }

        public virtual Lesson Lesson { get; set; }






    }
}
