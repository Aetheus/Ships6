using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ships6.Models;

namespace Ships6.Controllers
{
    public class CabinsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cabins
        public ActionResult Index()
        {
            var cabins = db.Cabins.Include(c => c.CabinType).Include(c => c.Cruise);
            return View(cabins.ToList());
        }

        // GET: Cabins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cabin cabin = db.Cabins.Find(id);
            if (cabin == null)
            {
                return HttpNotFound();
            }
            return View(cabin);
        }

        // GET: Cabins/Create
        public ActionResult Create()
        {
            ViewBag.CabinTypeID = new SelectList(db.CabinTypes, "CabinTypeID", "CabinTypeName");
            ViewBag.CruiseID = new SelectList(db.Cruises, "CruiseID", "CruiseName");
            return View();
        }

        // POST: Cabins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CabinID,CruiseID,CabinTypeID,CabinIsOccupied")] Cabin cabin)
        {
            if (ModelState.IsValid)
            {
                db.Cabins.Add(cabin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CabinTypeID = new SelectList(db.CabinTypes, "CabinTypeID", "CabinTypeName", cabin.CabinTypeID);
            ViewBag.CruiseID = new SelectList(db.Cruises, "CruiseID", "CruiseName", cabin.CruiseID);
            return View(cabin);
        }

        // GET: Cabins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cabin cabin = db.Cabins.Find(id);
            if (cabin == null)
            {
                return HttpNotFound();
            }
            ViewBag.CabinTypeID = new SelectList(db.CabinTypes, "CabinTypeID", "CabinTypeName", cabin.CabinTypeID);
            ViewBag.CruiseID = new SelectList(db.Cruises, "CruiseID", "CruiseName", cabin.CruiseID);
            return View(cabin);
        }

        // POST: Cabins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CabinID,CruiseID,CabinTypeID,CabinIsOccupied")] Cabin cabin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cabin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CabinTypeID = new SelectList(db.CabinTypes, "CabinTypeID", "CabinTypeName", cabin.CabinTypeID);
            ViewBag.CruiseID = new SelectList(db.Cruises, "CruiseID", "CruiseName", cabin.CruiseID);
            return View(cabin);
        }

        // GET: Cabins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cabin cabin = db.Cabins.Find(id);
            if (cabin == null)
            {
                return HttpNotFound();
            }
            return View(cabin);
        }

        // POST: Cabins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cabin cabin = db.Cabins.Find(id);
            db.Cabins.Remove(cabin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
