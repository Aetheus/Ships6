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
    public class CruiseCatalogueController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CruiseCatalogue
        [AllowAnonymous]
        public ActionResult Index()
        {
            var cruises = db.Cruises.Include(c => c.Operator);
            return View(cruises.ToList());
        }

        // GET: CruiseCatalogue/Details/5
        [AllowAnonymous]
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
