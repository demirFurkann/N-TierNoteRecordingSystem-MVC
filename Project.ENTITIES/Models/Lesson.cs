using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Lesson:BaseEntity
    {
        public string LessonName { get; set; }

        //Relational Properties

        public virtual List<Note> Notes { get; set; }





    }
}
