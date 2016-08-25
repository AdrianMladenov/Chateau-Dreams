using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChateauDreams.Models;
using ChateauDreams.Models.EnotourismModels;

namespace ChateauDreams.Controllers.EnotourismControllers
{
    public class WineHistoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WineHistories
        public ActionResult Index()
        {
            return View(db.WineHistories.ToList());
        }

        // GET: WineHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WineHistory wineHistory = db.WineHistories.Find(id);
            if (wineHistory == null)
            {
                return HttpNotFound();
            }
            return View(wineHistory);
        }

        // GET: WineHistories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WineHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Body")] WineHistory wineHistory)
        {
            if (ModelState.IsValid)
            {
                db.WineHistories.Add(wineHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wineHistory);
        }

        // GET: WineHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WineHistory wineHistory = db.WineHistories.Find(id);
            if (wineHistory == null)
            {
                return HttpNotFound();
            }
            return View(wineHistory);
        }

        // POST: WineHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Body")] WineHistory wineHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wineHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wineHistory);
        }

        // GET: WineHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WineHistory wineHistory = db.WineHistories.Find(id);
            if (wineHistory == null)
            {
                return HttpNotFound();
            }
            return View(wineHistory);
        }

        // POST: WineHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WineHistory wineHistory = db.WineHistories.Find(id);
            db.WineHistories.Remove(wineHistory);
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
