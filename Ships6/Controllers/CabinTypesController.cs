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
    public class CabinTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CabinTypes
        public ActionResult Index()
        {
            return View(db.CabinTypes.ToList());
        }

        // GET: CabinTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CabinType cabinType = db.CabinTypes.Find(id);
            if (cabinType == null)
            {
                return HttpNotFound();
            }
            return View(cabinType);
        }

        // GET: CabinTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CabinTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CabinTypeID,CabinTypeName,CabinTypePrice")] CabinType cabinType)
        {
            if (ModelState.IsValid)
            {
                db.CabinTypes.Add(cabinType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cabinType);
        }

        // GET: CabinTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CabinType cabinType = db.CabinTypes.Find(id);
            if (cabinType == null)
            {
                return HttpNotFound();
            }
            return View(cabinType);
        }

        // POST: CabinTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CabinTypeID,CabinTypeName,CabinTypePrice")] CabinType cabinType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cabinType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cabinType);
        }

        // GET: CabinTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CabinType cabinType = db.CabinTypes.Find(id);
            if (cabinType == null)
            {
                return HttpNotFound();
            }
            return View(cabinType);
        }

        // POST: CabinTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CabinType cabinType = db.CabinTypes.Find(id);
            db.CabinTypes.Remove(cabinType);
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
