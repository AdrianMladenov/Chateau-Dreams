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
    public class TastingRoomsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TastingRooms
        public ActionResult Index()
        {
            return View(db.TastingRooms.ToList());
        }

        // GET: TastingRooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TastingRoom tastingRoom = db.TastingRooms.Find(id);
            if (tastingRoom == null)
            {
                return HttpNotFound();
            }
            return View(tastingRoom);
        }

        // GET: TastingRooms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TastingRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Body")] TastingRoom tastingRoom)
        {
            if (ModelState.IsValid)
            {
                db.TastingRooms.Add(tastingRoom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tastingRoom);
        }

        // GET: TastingRooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TastingRoom tastingRoom = db.TastingRooms.Find(id);
            if (tastingRoom == null)
            {
                return HttpNotFound();
            }
            return View(tastingRoom);
        }

        // POST: TastingRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Body")] TastingRoom tastingRoom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tastingRoom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tastingRoom);
        }

        // GET: TastingRooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TastingRoom tastingRoom = db.TastingRooms.Find(id);
            if (tastingRoom == null)
            {
                return HttpNotFound();
            }
            return View(tastingRoom);
        }

        // POST: TastingRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TastingRoom tastingRoom = db.TastingRooms.Find(id);
            db.TastingRooms.Remove(tastingRoom);
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
