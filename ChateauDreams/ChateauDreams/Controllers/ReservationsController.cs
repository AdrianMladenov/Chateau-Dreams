using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChateauDreams.Models;
using ChateauDreams.Extensions;

namespace ChateauDreams.Controllers
{
    public class ReservationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reservations
        [Authorize]
        public ActionResult Index()
        {
            var reservations = db.Reservations.Include(r => r.Guest).ToList();
            return View(reservations);
        }

        // GET: Reservations/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservations reservations = db.Reservations.Find(id);
            if (reservations == null)
            {
                return HttpNotFound();
            }
            return View(reservations);
        }

        // GET: Reservations/Create
        [Authorize]
        public ActionResult Create()
        {
            var roomType = this.db.Rooms.Select(r => new SelectListItem
            {
                Text = r.Type.ToString() + " - " + r.Price.ToString() + "Euro",
                Value = r.Type.ToString()
            });
            return View(new ReservationViewModel { RoomType= roomType });
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RoomType,Persons,CheckInDate,CheckOutDate,Questions,Type")] ReservationViewModel reservations)
        {
            if (ModelState.IsValid)
            {
                var newReservation = new Reservations();
                newReservation.Guest = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                newReservation.Id = reservations.Id;
                newReservation.Persons = reservations.Persons;
                newReservation.Questions = reservations.Questions;
                newReservation.CheckInDate = reservations.CheckInDate;
                newReservation.CheckOutDate = reservations.CheckOutDate;
                newReservation.RoomType = reservations.Type;
                db.Reservations.Add(newReservation);
                db.SaveChanges();
                this.AddNotification("You have successfully created a Reservation.", NotificationType.INFO);
                return RedirectToAction("Index");
            }

            return View(reservations);
        }

        // GET: Reservations/Edit/5
        [Authorize(Roles = "Administrators")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservations reservations = db.Reservations.Find(id);
            if (reservations == null)
            {
                return HttpNotFound();
            }
            return View(reservations);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Administrators")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RoomType,Persons,CheckInDate,CheckOutDate,Questions")] Reservations reservations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservations).State = EntityState.Modified;
                db.SaveChanges();
                this.AddNotification("Reservation edited.", NotificationType.INFO);
                return RedirectToAction("Index");
            }
            return View(reservations);
        }

        // GET: Reservations/Delete/5
        [Authorize(Roles = "Administrators")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservations reservations = db.Reservations.Find(id);
            if (reservations == null)
            {
                return HttpNotFound();
            }
            this.AddNotification("Are you sure you want to delete the reservation?", NotificationType.WARNING);
            return View(reservations);
        }

        // POST: Reservations/Delete/5
        [Authorize(Roles = "Administrators")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservations reservations = db.Reservations.Find(id);
            db.Reservations.Remove(reservations);
            db.SaveChanges();
            this.AddNotification("Reservation deleted.", NotificationType.WARNING);
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
