using Ships6.Models;
using System;
using System.Collections.Generic;
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
            return Content("Placeholder");
        }
    }
}