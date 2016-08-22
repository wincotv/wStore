using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace wStoreWebApi.Controllers
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

        public ActionResult Knockout()
        {
            ViewBag.Title = "Knockout";

            return View("Knockout");
        }

        public ActionResult Angular()
        {
            ViewBag.Title = "Angular";

            return View("Angular");
        }
    }
}
