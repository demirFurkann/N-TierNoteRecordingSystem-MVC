using Project.BLL.Repositories.ConcRep;
using Project.ENTITIES.Models;
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
        StudentRepository _studRep;
        LessonRepository _lessonRep;
        public NoteController()
        {
            _notRep = new NoteRepository();
            _studRep = new StudentRepository();
            _lessonRep = new LessonRepository();
        }
        private List<StudentVM> GetStudentVMs()
        {
            return _studRep.Select(x => new StudentVM
            {
                ID = x.ID,

                FirstName = x.FirstName,
                LastName = x.LastName,

            }).ToList();

        }
        private List<LessonVM> GetLessonVMs()
        {
            return _lessonRep.Select(x => new LessonVM
            {
                ID = x.ID,
                LessonName = x.LessonName,
            }).ToList();
        }
        private List<NoteVM> GetNoteVMs()
        {
            return _notRep.Select(x => new NoteVM
            {
                ID= x.ID,
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
        public ActionResult ListNotes(string search)
        {
            List<NoteVM> notes = GetNoteVMs();

            if (notes != null && !String.IsNullOrEmpty(search))
            {
                notes = notes.Where(n => n.StudentName != null && n.StudentName.ToLower().Contains(search.ToLower())).ToList();
            }

            NoteListPageVM vpvm = new NoteListPageVM
            {
                Notes = notes,
            };

            return View(vpvm);
        }


        public ActionResult AddNote()
        {
            List<StudentVM> students = GetStudentVMs();
            List<LessonVM> lessons = GetLessonVMs();
            NoteAddUpdatePageVM note = new NoteAddUpdatePageVM
            {
                Lessons = lessons,
                Students = students,
                Note = new NoteVM()
            };
            return View(note);
        }
        [HttpPost]
        public ActionResult AddNote(NoteVM note)
        {
            Student student = _studRep.Find(note.ID);
            Lesson lesson = _lessonRep.Find(note.ID);
            Note n = new Note
            {
                Student = student,
                Lesson = lesson,
                LessonID = note.LessonID,
                StudentID = note.StudentID,
                Exam1 = note.Exam1,
                Exam2 = note.Exam2,
                Exam3 = note.Exam3,
               

            };
            _notRep.Add(n);
            return RedirectToAction("ListNotes");
        }
        public ActionResult UpdateNote(int id)
        {
            NoteVM note = _notRep.Where(x => x.ID == id).Select(x => new NoteVM
            {
                ID = x.ID,
                Exam1 = x.Exam1,
                Exam2 = x.Exam2,
                Exam3 = x.Exam3,
                //Avarage = Convert.ToInt32((x.Exam1 + x.Exam2 + x.Exam3 + x.Project) / 4),
                //Project = x.Project,
                //Case = Convert.ToInt32((x.Exam1 + x.Exam2 + x.Exam3 + x.Project) / 4) >= 50 ? true : false,

            }).FirstOrDefault();
            NoteAddUpdatePageVM npvm = new NoteAddUpdatePageVM
            {
                Note = note,
            };
            return View(npvm);
        }
        [HttpPost]
        public ActionResult UpdateNote(NoteVM note)
        {
            Note toBeUpdated = _notRep.Find(note.ID);
            toBeUpdated.Exam1 = note.Exam1;
            toBeUpdated.Exam2=note.Exam2;
            toBeUpdated.Exam3=note.Exam3;
            toBeUpdated.Avarage = note.Avarage = Convert.ToInt32((note.Exam1 + note.Exam2 + note.Exam3 + note.Project) / 4);
            toBeUpdated.Project = note.Project;
            toBeUpdated.Case = Convert.ToInt32((note.Exam1 + note.Exam2 + note.Exam3 + note.Project) / 4) >= 50 ? true : false;
            _notRep.Update(toBeUpdated);

            return RedirectToAction("ListNotes");
                

        }
        public ActionResult DeleteNote(int id)
        {
            _notRep.Destroy(_notRep.Find(id));
            return RedirectToAction("ListNotes");
        }

    }
}