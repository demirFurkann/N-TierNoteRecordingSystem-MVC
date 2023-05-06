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
    public class StudentController : Controller
    {
        StudentRepository _stuRep;
        public StudentController()
        {
            _stuRep = new StudentRepository();
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
        public ActionResult ListStudents()
        {
           List<StudentVM> student = GetListStudents();
            StudentListPageVM slpvm = new StudentListPageVM
            {
                Students = student,
            };
            return View(slpvm);
        }
    }
}