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
            var currentUser = manager.FindById(User.Identity.GetUserId());

            var objets = db.Objets.Include(o => o.Categorie).Where(o => o.proprietaire.Id == currentUser.Id);
            return View(objets);
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
            //ViewBag.cat = objet.Categorie;
            return View(objet);
        }

        // GET: Objet/Create
        public ActionResult Create()
        {
            ViewBag.ListeDesCategories = new SelectList(db.Categories, "Id", "Nom");
            return View();
        }

        // POST: Objet/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titre,Description,Tarif,Caution,")] Objet objet)
        {
            var test = ViewBag.ListeDesCategories;
            if (ModelState.IsValid)
            {
                
                //var categorieC = db.Categories.Find()
                var currentUser = manager.FindById(User.Identity.GetUserId());
                objet.proprietaire = currentUser;
                objet.Categorie = db.Categories.Find(4);
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
            ViewBag.ListeDesCategories = new SelectList(db.Categories, "Id", "Nom", objet.Categorie.Id );
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
