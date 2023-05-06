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
    public class LessonController : Controller
    {
        LessonRepository _lesRep;
        public LessonController()
        {
            _lesRep = new LessonRepository();
        }
        private List<LessonVM> GetLessonVMs()
        {
            return _lesRep.Select(x => new LessonVM
            {
                ID = x.ID,
                LessonName = x.LessonName,
            }).ToList();
        }

        public ActionResult ListLessons()
        {
            List<LessonVM> lessons = GetLessonVMs();
            LessonListPageVM lpvm = new LessonListPageVM
            {
                Lessons = lessons,
            };
          
            return View(lpvm);
        }

        public ActionResult AddLesson()
        {
            return View();
        }
        [HttpPost]  
        public ActionResult AddLesson(LessonVM lesson)
        {
            Lesson l = new Lesson
            {
                LessonName = lesson.LessonName,
            };
            _lesRep.Add(l);
            return RedirectToAction("ListLessons");
        }

        public ActionResult UpdateLesson(int id)
        {
            LessonVM lvm = _lesRep.Where(x => x.ID == id).Select(x => new LessonVM
            {
                ID = x.ID,
                LessonName = x.LessonName,
            }).FirstOrDefault();

            LessonAddUpdatePageVM lpvm = new LessonAddUpdatePageVM
            {
                Lesson =lvm,
            };

            return View(lpvm);
        }

        [HttpPost]
        public ActionResult UpdateLesson(LessonVM lesson )
        {
            Lesson updated = _lesRep.Find(lesson.ID);
            updated.LessonName=lesson.LessonName;
            _lesRep.Update(updated);
            return RedirectToAction("ListLessons");
        }

        public ActionResult DeleteLesson(int id)
        {
            _lesRep.Destroy(_lesRep.Find(id));
            return RedirectToAction("ListLessons");
        }
    }
}