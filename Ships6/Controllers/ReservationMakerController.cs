using Ships6.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

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


        public ActionResult History()
        {
            var userID = User.Identity.GetUserId();
            var reservations = (from rs in db.Reservations
                                where rs.UserID == userID
                                select rs).ToArray();

            ViewBag.reservations = reservations;

            return View();
        }
        
        public ActionResult Make(int id, string errorMsg = "")
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
            ViewBag.errorMsg = errorMsg;

            return View();
            //return Content("Placeholder");
        }

        [HttpPost]
        public ActionResult Make(FormCollection form)
        {
            int cabinTypeID = int.Parse(form["cabintypechoice"]);
            int cruiseID = int.Parse(form["cruiseid"]);

            Cruise cruise = db.Cruises.Find(cruiseID);

            var availableCabins = (     
                                        from cb in db.Cabins
                                        where cb.CruiseID == cruiseID && cb.CabinTypeID == cabinTypeID
                                        && !cb.CabinIsOccupied
                                        select cb
                                  );

            int numAvailable = availableCabins.Count();

            if (numAvailable > 0)
            {
                Cabin chosenCabin = availableCabins.First();
                chosenCabin.CabinIsOccupied = true;
                db.Entry(chosenCabin).State = EntityState.Modified;

                Reservation reservation = new Reservation
                {
                    ApplicationUser = db.Users.Find(User.Identity.GetUserId()),
                    Cabin = chosenCabin,
                    Cruise = cruise,
                    ReservationPrice = chosenCabin.CabinType.CabinTypePrice + cruise.CruisePrice,
                    ReservationTime = DateTime.Now
                };

                reservation.ApplicationUser = db.Users.Find(User.Identity.GetUserId());
                reservation.Cabin = chosenCabin;
                reservation.Cruise = cruise;
                reservation.ReservationPrice = chosenCabin.CabinType.CabinTypePrice + cruise.CruisePrice;
                reservation.ReservationTime = DateTime.Now;

                reservation.CabinID = reservation.Cabin.CabinID;
                reservation.CruiseID = reservation.Cruise.CruiseID;
                reservation.UserID = reservation.ApplicationUser.Id;


                db.Reservations.Add(reservation);
                
                
                //db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("History");
            }
            else
            {
                return RedirectToAction("Make", new { id = cruiseID, errorMsg = "Sorry, this cabin type has become unavailable" });
            }

            
        }
    }
}