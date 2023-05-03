using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Club:BaseEntity
    {
        public string ClubName { get; set; }
        public int Quato { get; set; }

        //Relational Properties

        public virtual List<Student> Students { get; set; }
    }
}
