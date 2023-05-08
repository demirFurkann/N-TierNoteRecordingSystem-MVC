using Project.BLL.Repositories.ConcRep;
using Project.ENTITIES.Models;
using Project.MVCUI.Models;
using Project.MVCUI.Models.PageVMs;
using Project.VM.PureVMs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Controllers
{
    public class StudentController : Controller
    {
        StudentRepository _stuRep;
        ClubRepository _clubRep;
        public StudentController()
        {
            _stuRep = new StudentRepository();
            _clubRep = new ClubRepository();
        }
        private List<StudentVM> GetListStudents()
        {
            return _stuRep.Select(x => new StudentVM
            {
                ID = x.ID,
                FirstName = x.FirstName,
                Gender = x.Gender,
                LastName = x.LastName,
                Image = x.Image,
                Club = x.Club.ClubName
            }).ToList();
        }
        private List<ClubVM> GetClubVM()
        {
            return _clubRep.Select(x => new ClubVM
            {
                ID = x.ID,
                ClubName = x.ClubName,
                Quato = x.Quato,
            }).ToList();

        }
        public ActionResult ListStudents()
        {
            List<StudentVM> student = GetListStudents();
            StudentListPageVM slpvm = new StudentListPageVM
            {
                Students = student,
            };
            return View(slpvm);
        }

        public ActionResult AddStudent()
        {
            List<ClubVM> clubs = GetClubVM();
            StudentAddUpdatePageVM apvm = new StudentAddUpdatePageVM
            {
                Clubs = clubs,
            };
            return View(apvm);
        }
        [HttpPost]
        public ActionResult AddStudent(StudentVM student, HttpPostedFileBase image, string fileName)
        {
            Student s = new Student
            {
                FirstName = student.FirstName,
                Gender = student.Gender,
                LastName = student.LastName,
                Image = student.Image = ImageUploader.ImageUpload("/Pictures/", image, fileName),
                ClubID = student.ClubID,
                //Burayı bida kontrol ediceksın 

            };
            _stuRep.Add(s);
            return RedirectToAction("ListStudents");
        }

        public ActionResult UpdateStudent(int id)
        {
            StudentVM svm = _stuRep.Where(x => x.ID == id).Select(x => new StudentVM
            {
                ID = x.ID,
                FirstName = x.FirstName,
                Gender = x.Gender,
                LastName = x.LastName,
                Image = x.Image,
                ClubID = x.ClubID,

            }).FirstOrDefault();

            StudentAddUpdatePageVM spvm = new StudentAddUpdatePageVM
            {
                Student = svm,
            };
            return View(spvm);
        }
        [HttpPost]
        public ActionResult UpdateStudent(StudentVM student, HttpPostedFileBase image, string fileName)
        {
            Student updated = _stuRep.Find(student.ID);
            updated.FirstName = student.FirstName;
            updated.LastName = student.LastName;
            updated.Image = student.Image = ImageUploader.ImageUpload("/Pictures", image, fileName);
            updated.Gender = student.Gender;
            updated.ClubID = student.ClubID;
            _stuRep.Update(updated);
            return RedirectToAction("ListStudents");
        }


        public ActionResult DeleteStudent(int id)
        {
            _stuRep.Destroy(_stuRep.Find(id));
            return RedirectToAction("ListStudents");
        }
    }
}