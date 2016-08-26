using ChateauDreams.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChateauDreams.Controllers
{
    public class GalleryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "Administrators")]
        [HttpGet]
        public ActionResult Create()
        {
            //ViewData["My Message"] = "Albums"; // ? ili viewBag
            return View();
        }
        
    }
}