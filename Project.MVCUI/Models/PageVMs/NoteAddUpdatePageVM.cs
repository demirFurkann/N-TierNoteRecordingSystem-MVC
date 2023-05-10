using Project.VM.PureVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.MVCUI.Models.PageVMs
{
    public class NoteAddUpdatePageVM
    {
        public NoteVM Note{ get; set; }
        public List<StudentVM> Students{ get; set; }
        public StudentVM Student { get; set; }
        public List<LessonVM> Lessons { get; set; }
        public LessonVM Lesson{ get; set; }


    }
}