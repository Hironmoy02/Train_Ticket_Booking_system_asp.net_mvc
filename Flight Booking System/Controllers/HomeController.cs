using Rail_Booking_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rail_Booking_System.Controllers
{
    public class HomeController : Controller
    {
        private TRSContext db = new TRSContext();
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        [OutputCache(NoStore = true, Duration =0,VaryByParam ="None")]
        public ActionResult AdminHome()
        {
            return View();
        }

        public ActionResult UserHome()
        {
            ViewBag.From = new SelectList(db.Stations,"StationId", "StationName");
            ViewBag.To = new SelectList(db.Stations, "StationId", "StationName");
            return View();
        }

        [HttpPost]
        public ActionResult UserHome(FormCollection f)
        {
            string From = f["StationId"];
            string To = f["StationId1"];
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Details()
        {
            int userId = (int)Session["userid"];
            UserLogin user = db.UserLogins.Find(userId);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }


    }
}