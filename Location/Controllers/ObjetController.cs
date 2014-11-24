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
    public class ObjetController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private UserManager<ApplicationUser> manager;

        public ObjetController()
        {
            manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

        }

        // GET: Objet
        public ActionResult Index()
        {
            return View(db.Objets.ToList());
        }

        // GET: Objet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objet objet = db.Objets.Find(id);
            if (objet == null)
            {
                return HttpNotFound();
            }
            return View(objet);
        }

        // GET: Objet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Objet/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titre,Description,Tarif,Caution")] Objet objet)
        {
           

            if (ModelState.IsValid)
            {
                var currentUser = manager.FindById(User.Identity.GetUserId());
                objet.proprietaire = currentUser;
                db.Objets.Add(objet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(objet);
        }

        // GET: Objet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objet objet = db.Objets.Find(id);
            if (objet == null)
            {
                return HttpNotFound();
            }
            return View(objet);
        }

        // POST: Objet/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titre,Description,Tarif,Caution")] Objet objet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objet);
        }

        // GET: Objet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objet objet = db.Objets.Find(id);
            if (objet == null)
            {
                return HttpNotFound();
            }
            return View(objet);
        }

        // POST: Objet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Objet objet = db.Objets.Find(id);
            db.Objets.Remove(objet);
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
