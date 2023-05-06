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
    public class ClubController : Controller
    {
        ClubRepository _clubRep;
        public ClubController()
        {
            _clubRep = new ClubRepository();
        }

        public List<ClubVM> GetClubsVM()
        {
            return _clubRep.Select(x => new ClubVM
            {
                ID = x.ID,
                ClubName = x.ClubName,
                Quato = x.Quato,
            }).ToList();
        }
        public ActionResult ListClubs()
        {
            List<ClubVM> club = GetClubsVM();
            ClubListPageVM cpvm = new ClubListPageVM
            {
                Clubs = club,
            };
            return View(cpvm);
        }
        public ActionResult AddClub()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddClub(ClubVM club)
        {
            Club c = new Club
            {
                ClubName = club.ClubName,
                Quato = club.Quato,
            };
            _clubRep.Add(c);
            return RedirectToAction("ListClubs");
        }
        public ActionResult UpdateClub(int id)
        {
            ClubVM club = _clubRep.Where(x => x.ID == id).Select(x => new ClubVM
            {
                ID = x.ID,
                ClubName = x.ClubName,
                Quato = x.Quato,
            }).FirstOrDefault();
            ClubAddUpdatePageVM cpvm = new ClubAddUpdatePageVM
            {
                Club = club,
            };

            return View(cpvm);
        }
        [HttpPost]
        public ActionResult UpdateClub(ClubVM club)
        {
            Club updated = _clubRep.Find(club.ID);
            updated.ClubName = club.ClubName;
            updated.Quato = club.Quato;
            _clubRep.Update(updated);
            return RedirectToAction("ListClubs");
        }

        public ActionResult DeleteClub(int id)
        {
            _clubRep.Destroy(_clubRep.Find(id));
            return RedirectToAction("ListClubs");
        }
    }
}