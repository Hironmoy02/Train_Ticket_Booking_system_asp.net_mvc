using Rail_Booking_System.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rail_Booking_System.Controllers
{
    [Authorize]

    public class ScheduleController : Controller
    {
        private TRSContext db = new TRSContext();

        // GET: Schedule
        public ActionResult Index()
        {
            var schedules = db.Schedules.ToList();
            return View(schedules);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            Schedule schedules = new Schedule();
            schedules.From = "";
            schedules.To = "";
            schedules.TrainId = 0;
            return View(schedules);
        }

        [HttpPost]
        public ActionResult Create(Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                Rail fl = db.Rails.Find(schedule.RailId);
                if(fl==null)
                {
                    ViewBag.Message = "TrainId is invalid";
                    return View("Error");
                }
                schedule.From = fl.From;
                schedule.To = fl.To;
                schedule.TrainId = fl.TrainId;
                db.Schedules.Add(schedule);
                db.SaveChanges();
                return RedirectToAction("Index","Schedule");
            }

            return View(schedule);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var schedules = db.Schedules.Find(id);

            if (schedules == null)
            {
                return HttpNotFound();
            }

            return View(schedules);
        }

        [HttpPost]
        public ActionResult Edit(Schedule schedules)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schedules).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(schedules);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var schedules = db.Schedules.Find(id);

            if (schedules == null)
            {
                return HttpNotFound();
            }

            return View(schedules);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var schedules = db.Schedules.Find(id);

            if (schedules == null)
            {
                return HttpNotFound();
            }

            db.Schedules.Remove(schedules);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SearchSchedule(FormCollection f)
        {
            int FromId = int.Parse(f["from"]);
            string From = db.Stations.Find(FromId).City;
            int ToId = int.Parse(f["to"]);
            string To = db.Stations.Find(ToId).City;   

            DateTime RailDate = DateTime.ParseExact(f["date"],"yyyy-MM-dd",null);
            //return Content(From + "-" + To + "-" + RailDate);
            List<Schedule> schedules = db.Schedules.Where(fl => fl.From == From && fl.To == To && fl.RailDate == RailDate).ToList();
            return View(schedules);
        }

    }
}
