using Advertisement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Advertisement.Controllers
{
    public class HomeController : Controller
    {
        private AdvertisementContext db = new AdvertisementContext();
        public ActionResult Index()
        {
            db.Ads.ToList();
            ViewBag.ad1 = db.Ads.Find(13);
            ViewBag.ad2 = db.Ads.Find(14);
            ViewBag.ad3 = db.Ads.Find(22);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}