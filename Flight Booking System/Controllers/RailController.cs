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
    public class RailController : Controller
    {
        private TRSContext db = new TRSContext();

        // GET: Rail
        [AllowAnonymous]
        public ActionResult Index()
        {
            var rails = db.Rails.ToList();
            return View(rails);
        }

        [Authorize(Roles = "Admin")]
        // GET: Rail/Create
        public ActionResult Create()
        {
            ViewBag.From = new SelectList(db.Stations, "StationId", "StationName");
            ViewBag.To = new SelectList(db.Stations, "StationId", "StationName");
            ViewBag.TraiNs = new SelectList(db.Trains,"TrainId","TrainName");
            ViewBag.Stations = new SelectList(db.Stations, "StationId", "StationName");
            return View();
        }

        // POST: Rail/Create
        [HttpPost]
        public ActionResult Create(FormCollection rail)
        {
            
            try
            {
                Rail fl = new Rail();
                int From = int.Parse(rail["StationId"]);
                int To = int.Parse(rail["StationId1"]);
               // return Content(From + "-" + To);
                
                Station arp = db.Stations.Where(ar=>ar.StationId == From).FirstOrDefault();
                String FromStation = arp.StationName;
                Station arp1 = db.Stations.Where(ar1 => ar1.StationId == To).FirstOrDefault();
                string ToStation = arp1.StationName;

                fl.TrainId = int.Parse(rail["TrainId"]);
                Train a = db.Trains.Find(fl.TrainId);
                fl.TotalSeatsCapacity = 0;
                fl.FromCode = FromStation;
                fl.ToCode = ToStation;
                fl.StationId = int.Parse(rail["StationId"]);
                //fl.RailDate = DateTime.Parse(rail["RailDate"]);

                fl.From = arp.City;
                fl.To = arp1.City;
               
                fl.ArrivalTime = "0";
                fl.DepartureTime = "0";
            
                db.Rails.Add(fl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                throw ex;
            }
            // return View(rail);
        }


        // GET: Rail/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var rail = db.Rails.Find(id);

            if (rail == null)
            {
                return HttpNotFound();
            }

            return View(rail);
        }

        // POST: Rail/Edit/5
        [HttpPost]
        public ActionResult Edit(Rail rail)
        {
            if (ModelState.IsValid)
            {
                //return Content(rail.TotalSeatsCapacity + "-1");
                db.Entry(rail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rail);
        }

        // GET: Rail/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var rail = db.Rails.Find(id);

            if (rail == null)
            {
                return HttpNotFound();
            }

            return View(rail);
        }

        // POST: Rail/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var rail = db.Rails.Find(id);

            if (rail == null)
            {
                return HttpNotFound();
            }

            db.Rails.Remove(rail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
