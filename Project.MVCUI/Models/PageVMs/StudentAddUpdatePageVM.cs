using Project.VM.PureVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.MVCUI.Models.PageVMs
{
    public class StudentAddUpdatePageVM
    {
        public StudentVM Student { get; set; }
        public List<ClubVM> Clubs { get; set; }
        public ClubVM Club { get; set; }
    }
}