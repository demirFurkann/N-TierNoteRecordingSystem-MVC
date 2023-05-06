using Project.BLL.Repositories.ConcRep;
using Project.MVCUI.Models.PageVMs;
using Project.VM.PureVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Controllers
{
    public class NoteController : Controller
    {
        NoteRepository _notRep;
        public NoteController()
        {
            _notRep = new NoteRepository();
        }
        private List<NoteVM> GetNoteVMs()
        {
            return _notRep.Select(x => new NoteVM
            {

                Exam1 = x.Exam1,
                Exam2 = x.Exam2,
                Exam3 = x.Exam3,
                Case = x.Case,
                Avarage = x.Avarage,
                Project = x.Project,
                LessonName = x.Lesson.LessonName,
                StudentName = x.Student.FirstName
            }).ToList();
        }
        public ActionResult ListNotes()
        {
            List<NoteVM> notes = GetNoteVMs();
            NoteListPageVM vpvm = new NoteListPageVM
            {
                Notes = notes,
            };
            return View(vpvm);
        }
    }
}