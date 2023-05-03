using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Student:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public string Gender { get; set; }

        public int? ClubID { get; set; }


        //Relational Properties

        public virtual List<Note> Notes { get; set; }

        public virtual Club Club { get; set; }

    }
}
