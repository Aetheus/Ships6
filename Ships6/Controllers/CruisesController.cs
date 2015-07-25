using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ships6.Models;
using System.Diagnostics;

namespace Ships6.Controllers
{
    public class CruisesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cruises
        [Authorize(Roles = "canEdit")]
        public ActionResult Index()
        {
            var cruises = db.Cruises.Include(c => c.Operator);
            return View(cruises.ToList());
        }

        // GET: Cruises/Details/5
        [Authorize(Roles = "canEdit")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cruise cruise = db.Cruises.Find(id);
            if (cruise == null)
            {
                return HttpNotFound();
            }
            return View(cruise);
        }

        // GET: Cruises/Create
        [Authorize(Roles = "canEdit")]
        public ActionResult Create()
        {
            ViewBag.OperatorID = new SelectList(db.Operators, "OperatorID", "OperatorName");
            ViewBag.DestinationsList = new SelectList(db.Destinations,"DestinationID","DestinationName");
            ViewBag.DestinationNum = 6;
            return View();
        }

        // POST: Cruises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult Create([Bind(Include = "CruiseID,OperatorID,CruiseName,CruiseDescription,CruiseImage,CruisePrice,CruiseDepartureTime,CruiseDayLength")] Cruise cruise,
                                    FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                //Debug.WriteLine("dEBUG: WE GOT THIS: " + collection["destination1"].ToString());
                db.Cruises.Add(cruise);
                db.SaveChanges();

                db.Entry(cruise).GetDatabaseValues();
                int cruiseID = cruise.CruiseID;

                var destinations = collection.AllKeys
                                    .Where(k => k.StartsWith("destinationChoice"))
                                    .ToDictionary(k => k, k => collection[k]);
                int counter = 1;
                foreach (KeyValuePair<string,string> pair in destinations){
                    Debug.WriteLine("Key is: " + pair.Key + " While Value is " + pair.Value);
                    db.CruiseDestinations.Add(
                        new CruiseDestination
                        {
                            CruiseID = cruiseID,
                            DestinationID = int.Parse(pair.Value),
                            tripOrder = counter
                        }                    
                    );
                    counter++;
                }
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.OperatorID = new SelectList(db.Operators, "OperatorID", "OperatorName", cruise.OperatorID);
            return View(cruise);
        }

        // GET: Cruises/Edit/5
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit(int? id)
        {
            ViewBag.DestinationsList = new SelectList(db.Destinations, "DestinationID", "DestinationName");
            ViewBag.DestinationNum = 6;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cruise cruise = db.Cruises.Find(id);
            if (cruise == null)
            {
                return HttpNotFound();
            }
            ViewBag.OperatorID = new SelectList(db.Operators, "OperatorID", "OperatorName", cruise.OperatorID);


            return View(cruise);
        }

        // POST: Cruises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit([Bind(Include = "CruiseID,OperatorID,CruiseName,CruiseDescription,CruiseImage,CruisePrice,CruiseDepartureTime,CruiseDayLength")] Cruise cruise, 
            FormCollection collection, HttpPostedFileBase imageFile = null)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.ContentLength > 0)
                {
                    cruise.CruiseImage = new byte[imageFile.ContentLength];
                    imageFile.InputStream.Read(cruise.CruiseImage, 0, imageFile.ContentLength);
                }

                db.Entry(cruise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            int cruiseID = cruise.CruiseID;
            var destinations = collection.AllKeys
                                .Where(k => k.StartsWith("destinationChoice"))
                                .ToDictionary(k => k, k => collection[k]);
            int counter = 1;
            foreach (KeyValuePair<string, string> pair in destinations)
            {
                Debug.WriteLine("Key is: " + pair.Key + " While Value is " + pair.Value);
                db.CruiseDestinations.Add(
                    new CruiseDestination
                    {
                        CruiseID = cruiseID,
                        DestinationID = int.Parse(pair.Value),
                        tripOrder = counter
                    }
                );
                counter++;
            }
            db.SaveChanges();


            ViewBag.OperatorID = new SelectList(db.Operators, "OperatorID", "OperatorName", cruise.OperatorID);
            return View(cruise);
        }

        // GET: Cruises/Delete/5
        [Authorize(Roles = "canEdit")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cruise cruise = db.Cruises.Find(id);
            if (cruise == null)
            {
                return HttpNotFound();
            }
            return View(cruise);
        }

        // POST: Cruises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult DeleteConfirmed(int id)
        {
            Cruise cruise = db.Cruises.Find(id);
            db.Cruises.Remove(cruise);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "canEdit")]
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
