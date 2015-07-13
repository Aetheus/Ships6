using Ships6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ships6.Controllers
{
    public class CruiseCompareController : Controller
    {
        //Session["CompareList"]
        private ApplicationDbContext db = new ApplicationDbContext();
        
        [AllowAnonymous]
        public ActionResult Index(int id)
        {
            return Content("Whoops? How'd you get here?");
        }

        [AllowAnonymous]
        public ActionResult Add(int id)
        {
            Session["CompareList"] = (Session["CompareList"] != null) ? Session["CompareList"] : new List<int>();
            List<int> compareList = (List<int>)Session["CompareList"];

            if (compareList.IndexOf(id) < 0)
            {
                compareList.Add(id);
                Session["CompareList"] = compareList;
            }

            return Content("id is:" + id + "; current comparelist is: " + string.Join(",", compareList.ToArray()));
        }

        [AllowAnonymous]
        public ActionResult Remove(int id)
        {
            Session["CompareList"] = (Session["CompareList"] != null) ? Session["CompareList"] : new List<int>();
            List<int> compareList = (List<int>)Session["CompareList"];

            if(compareList != null){
                if (compareList.IndexOf(id) >= 0){
                    compareList.Remove(id);
                    Session["CompareList"] = compareList;
                    return Content("Cruise removed from compare list");
                }
                else{
                    return Content("not found");
                }
            }
            else{
                return Content("not found");
            }

        }
    
        [AllowAnonymous]
        public ActionResult View(bool isPartial = false)
        {
            ViewBag.isPartialView = isPartial;
            List<Cruise> cruiseList = new List<Cruise>();

            if (Session["CompareList"] != null)
            {
                foreach (int id in (List<int>)Session["CompareList"])
                {
                    cruiseList.Add(db.Cruises.Find(id));
                }
            }


            return View(cruiseList.ToArray());
        }
    }
}