using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace ChateauDreams.Controllers
{
    public class HotelController : Controller
    {
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Rooms()
        {
            ViewBag.Message = "This is the page for room info.";

            return View();
        }

        public ActionResult Restaurant()
        {
            ViewBag.Message = "This is the restaurant page.";

            return View();
        }
    }
}