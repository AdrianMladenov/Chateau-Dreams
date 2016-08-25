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
    public class EnotourismHistoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EnotourismHistories
        public ActionResult Index()
        {
            return View(db.EnotourismHistories.ToList());
        }

        // GET: EnotourismHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnotourismHistory enotourismHistory = db.EnotourismHistories.Find(id);
            if (enotourismHistory == null)
            {
                return HttpNotFound();
            }
            return View(enotourismHistory);
        }

        // GET: EnotourismHistories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnotourismHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Body")] EnotourismHistory enotourismHistory)
        {
            if (ModelState.IsValid)
            {
                db.EnotourismHistories.Add(enotourismHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(enotourismHistory);
        }

        // GET: EnotourismHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnotourismHistory enotourismHistory = db.EnotourismHistories.Find(id);
            if (enotourismHistory == null)
            {
                return HttpNotFound();
            }
            return View(enotourismHistory);
        }

        // POST: EnotourismHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Body")] EnotourismHistory enotourismHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enotourismHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enotourismHistory);
        }

        // GET: EnotourismHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnotourismHistory enotourismHistory = db.EnotourismHistories.Find(id);
            if (enotourismHistory == null)
            {
                return HttpNotFound();
            }
            return View(enotourismHistory);
        }

        // POST: EnotourismHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnotourismHistory enotourismHistory = db.EnotourismHistories.Find(id);
            db.EnotourismHistories.Remove(enotourismHistory);
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
