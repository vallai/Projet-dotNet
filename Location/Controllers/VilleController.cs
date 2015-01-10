using Location.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Location.Controllers
{
    public class VilleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ville/Villes
        public ActionResult Villes(String recherche)
        {
            List<Ville> villesRecherchees = new List<Ville>();
            if (!string.IsNullOrWhiteSpace(recherche))
            {
                villesRecherchees = db.Villes.ToList().Where(v => v.Nom.StartsWith(recherche, StringComparison.CurrentCultureIgnoreCase)).OrderBy(v => v.Nom).ToList();
            }

            return new JsonResult { Data = (villesRecherchees), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        // GET: Ville/Lieux
        public ActionResult Lieux(String recherche)
        {
            List<String> lieuxRecherches = new List<String>();
            List<Ville> villesRecherchees = new List<Ville>();
            List<Departement> departementsRecherches = new List<Departement>();
            List<Region> regionsRecherchees = new List<Region>();

            if (!string.IsNullOrWhiteSpace(recherche))
            {
                villesRecherchees = db.Villes.ToList().Where(v => v.Nom.StartsWith(recherche, StringComparison.CurrentCultureIgnoreCase)).OrderBy(v => v.Nom).ToList();
                departementsRecherches = db.Departements.ToList().Where(d => d.Nom.StartsWith(recherche, StringComparison.CurrentCultureIgnoreCase)).OrderBy(d => d.Nom).ToList();
                regionsRecherchees = db.Regions.ToList().Where(r => r.Nom.StartsWith(recherche, StringComparison.CurrentCultureIgnoreCase)).OrderBy(r => r.Nom).ToList();
            }
            
            foreach (var region in regionsRecherchees)
            {
                lieuxRecherches.Add(region.Nom);
            }
            foreach (var departement in departementsRecherches)
            {
                lieuxRecherches.Add(departement.Nom);
            }
            foreach (var ville in villesRecherchees)
            {
                lieuxRecherches.Add(ville.Nom);
            }

                return new JsonResult { Data = (lieuxRecherches), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
