using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChateauDreams.Models;
using ChateauDreams.Models.Enotourism;

namespace ChateauDreams.Controllers.Admin
{
    public class EnotourismHistoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EnotourismHistory
        public ActionResult Index()
        {
            return View("~/Views/Enotourism/EnotourismHistory/EnotourismHistory.cshtml", db.EnotourismHistories.ToList());
        }

        // GET: EnotourismHistory/Details/5
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
            return View("~/Views/Enotourism/EnotourismHistory/Details.cshtml", enotourismHistory);
        }

        // GET: EnotourismHistory/Create
        public ActionResult Create()
        {
            return View("~/Views/EnotourismHistory/Create.cshtml");
        }

        // POST: EnotourismHistory/Create
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

        // GET: EnotourismHistory/Edit/5
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
            return View("~/Views/Enotourism/EnotourismHistory/Edit.cshtml", enotourismHistory);
        }

        // POST: EnotourismHistory/Edit/5
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
            return View("~/Views/Enotourism/EnotourismHistory/EnotourismHistory.cshtml", enotourismHistory);
        }

        // GET: EnotourismHistory/Delete/5
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
            return View("~/Views/Enotourism/EnotourismHistory/Delete.cshtml", enotourismHistory);
        }

        // POST: EnotourismHistory/Delete/5
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
