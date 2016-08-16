using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace ChateauDreams.Controllers
{
    public class EnotourismController : Controller
    {
        public ActionResult WineHistory()
        {
            ViewBag.Message = "THIS IS FOR THE HISTORY OF WINE";

            return View();
        }

        

        public ActionResult EnotourismHistory()
        {
            ViewBag.Message = "THIS IS FOR THE HISTORY OF ENOTOURISM";

            return View();
        }

        public ActionResult TastingRoom()
        {
            ViewBag.Message = "THIS IS FOR THE TASTING ROOM";

            return View();
        }

    }
}