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
    public class TastingRoomController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TastingRoom
        public ActionResult Index()
        {
            return View("~/Views/Enotourism/TastingRoom/TastingRoom.cshtml", db.TastingRooms.ToList());
        }

        // GET: TastingRoom/Details/5
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
            return View("~/Views/Enotourism/TastingRoom/Details.cshtml", tastingRoom);
        }

        // GET: TastingRoom/Create
        public ActionResult Create()
        {
            return View("~/Views/Enotourism/TastingRoom/Create.cshtml");
        }

        // POST: TastingRoom/Create
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

        // GET: TastingRoom/Edit/5
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
            return View("~/Views/Enotourism/TastingRoom/Edit.cshtml", tastingRoom);
        }

        // POST: TastingRoom/Edit/5
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

        // GET: TastingRoom/Delete/5
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
            return View("~/Views/Enotourism/TastingRoom/Delete.cshtml", tastingRoom);
        }

        // POST: TastingRoom/Delete/5
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
