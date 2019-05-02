using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        public ActionResult Sermons()
        {
            ViewBag.Message = "Your sermons page";
            return View();
        }
        public ActionResult Events()
        {
            ViewBag.Message = "Your events page";
            return View();

        }
        public ActionResult Homecells()
        {
            ViewBag.Message = "Your location page";
            return View();

        }
        public ActionResult Giving()
        {
            ViewBag.Message = "Your givings page";
            return View();

        }
        public ActionResult Ministries()
        {
            ViewBag.Message = "Your location page";
            return View();
        }

    }
}