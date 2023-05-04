using Project.BLL.DesignPatterns.SingletonPattern;
using Project.BLL.Repositories.ConcRep;
using Project.DAL.ContextClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Controllers
{
    public class DefaultController : Controller
    {
        
        LessonRepository _lessRep;

        public DefaultController()
        {
            
            _lessRep = new LessonRepository();
        }
        public ActionResult Index()
        {
            _lessRep.GetAll();
            return View();
        }
    }
}