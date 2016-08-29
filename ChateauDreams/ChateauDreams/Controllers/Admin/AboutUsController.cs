using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChateauDreams.Models;
using ChateauDreams.Models.Hotel;

namespace ChateauDreams.Controllers.Admin
{
    public class AboutUsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AboutUs
        public ActionResult Index()
        {
            return View("~/Views/Hotel/AboutUs/AboutUs.cshtml", db.AboutUs.ToList());
        }

        // GET: AboutUs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutUs aboutUs = db.AboutUs.Find(id);
            if (aboutUs == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Hotel/AboutUs/Details.cshtml", aboutUs);
        }

        // GET: AboutUs/Create
        public ActionResult Create()
        {
            return View("~/Views/Hotel/AboutUs/Create.cshtml");
        }

        // POST: AboutUs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Text")] AboutUs aboutUs)
        {
            if (ModelState.IsValid)
            {
                db.AboutUs.Add(aboutUs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("~/Views/Hotel/AboutUs/Create.cshtml", aboutUs);
        }

        // GET: AboutUs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutUs aboutUs = db.AboutUs.Find(id);
            if (aboutUs == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Hotel/AboutUs/Edit.cshtml", aboutUs);
        }

        // POST: AboutUs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Text")] AboutUs aboutUs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aboutUs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aboutUs);
        }

        // GET: AboutUs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutUs aboutUs = db.AboutUs.Find(id);
            if (aboutUs == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Hotel/AboutUs/Delete.cshtml", aboutUs);
        }

        // POST: AboutUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AboutUs aboutUs = db.AboutUs.Find(id);
            db.AboutUs.Remove(aboutUs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
