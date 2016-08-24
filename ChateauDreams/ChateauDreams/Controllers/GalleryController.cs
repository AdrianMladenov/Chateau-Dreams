using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChateauDreams.Controllers
{
    public class GalleryController : Controller
    {
        public ActionResult Albums()
        {
            //ViewData["My Message"] = "Albums"; // ? ili viewBag
            return View();
        }
        
    }
}