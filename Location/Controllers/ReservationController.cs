using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Location.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Location.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private UserManager<ApplicationUser> manager;

        public ReservationController()
        {
            manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }

        // GET: Reservation
        public ActionResult Index()
        {
            var currentUser = manager.FindById(User.Identity.GetUserId());
            return View(db.Reservations.Where(r => r.utilisateur.Id == currentUser.Id).ToList());
        }

        //public ActionResult Create([Bind(Include = "Id,dateDebut,dateFin")] Reservation reservation)
        [HttpPost]
        public ActionResult Create()
        {
            var test1 = Request["debutJour"];
            var test2 = Request["debutMois"];
            var test3 = Request["debutAnnee"];
            var test4 = Request["finJour"];
            var test5 = Request["finMois"];
            var test6 = Request["finAnnee"];

            Reservation reservation = new Reservation
            {
                objet =  db.Objets.Find(int.Parse(Request["objet"])),
                utilisateur = manager.FindById(User.Identity.GetUserId()),
                dateDebut = new DateTime(int.Parse(Request["debutAnnee"]),int.Parse(Request["debutMois"]),int.Parse(Request["debutJour"])),
                dateFin = new DateTime(int.Parse(Request["finAnnee"]), int.Parse(Request["finMois"]), int.Parse(Request["finJour"]))
            };
            db.Reservations.Add(reservation);
            db.SaveChanges();

            return RedirectToAction("Index", "Reservation");

        }

        // GET: Reservation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            var currentUser = manager.FindById(User.Identity.GetUserId());
            if (reservation.utilisateur != currentUser)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            return View(reservation);
        }

        // POST: Reservation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            db.Reservations.Remove(reservation);
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
