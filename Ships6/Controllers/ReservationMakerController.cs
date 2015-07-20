using Ships6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ships6.Controllers
{
    public class ReservationMakerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ReservationMaker
        public ActionResult Index()
        {
            return Content("invalid page");
        }

        
        public ActionResult Make(int id)
        {
            var cabins = (from cb in db.Cabins
                          where cb.CruiseID == id && !cb.CabinIsOccupied 
                          select cb).ToList();

            Cruise cruise = (   from cr in db.Cruises
                                where cr.CruiseID == id
                                select cr   ).First();

            var cabinChoices = cabins.GroupBy(test => test.CabinType).Select(grp => grp.First());


            ViewBag.cruise = cruise;
            ViewBag.CabinChoices = cabinChoices;


            return View();
            //return Content("Placeholder");
        }
    }
}