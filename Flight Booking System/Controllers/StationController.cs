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

    public class StationController : Controller

    {
        private TRSContext db = new TRSContext();

        // GET: Station
        public ActionResult Index()
        {
            var stations = db.Stations.ToList();
            return View(stations);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Station stations)
        {
            if (ModelState.IsValid)
            {
                db.Stations.Add(stations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stations);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var stations = db.Stations.Find(id);

            if (stations == null)
            {
                return HttpNotFound();
            }

            return View(stations);
        }

        [HttpPost]
        public ActionResult Edit(Station stations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stations);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var stations = db.Stations.Find(id);

            if (stations == null)
            {
                return HttpNotFound();
            }

            return View(stations);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Station stations = db.Stations.Find(id);

            //if (stations == null)
            //{
            //    return HttpNotFound();
            //}

            db.Stations.Remove(stations);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}