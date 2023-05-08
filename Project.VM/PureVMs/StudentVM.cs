using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.VM.PureVMs
{
    public class StudentVM
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public string Gender { get; set; }
        public int? ClubID { get; set; }
        public string Club { get; set; }
    }
}
