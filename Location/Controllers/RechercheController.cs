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
    public class RechercheController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Recherche
        public ActionResult Index(String keyword, String categorie, String location)
        {
            List<Objet> objetsRecherches = db.Objets.Include(o => o.Categorie).ToList();

            if (keyword != null)
            {
                objetsRecherches = objetsRecherches.Where(o => o.Titre.IndexOf(keyword, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();
            }
            if (categorie != null)
            {
                objetsRecherches = objetsRecherches.Where(o => o.Categorie.Nom.IndexOf(categorie, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();
            }
            if (location != null)
            {
                // Recherche par ville
                Ville rechercheVille = db.Villes.SingleOrDefault(ville => ville.Nom == location);
                if (rechercheVille != null)
                {
                    objetsRecherches = objetsRecherches.Where(o => o.proprietaire.Ville.Nom.IndexOf(rechercheVille.Nom, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();
                }

                // Recherche par code postal
                int codePostal;
                if (int.TryParse(location, out codePostal))
                {
                    Ville rechercheCodePostal = db.Villes.SingleOrDefault(ville => ville.Code_postal == codePostal);
                    if (rechercheCodePostal != null)
                    {
                        objetsRecherches = objetsRecherches.Where(o => o.proprietaire.Ville.Nom.IndexOf(rechercheCodePostal.Nom, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();
                    }
                }

                // Recherche par departement
                Departement rechercheDepartement = db.Departements.SingleOrDefault(departement => departement.Nom == location);
                if (rechercheDepartement != null)
                {
                    objetsRecherches = objetsRecherches.Where(o => o.proprietaire.Ville.Departement.Nom.IndexOf(rechercheDepartement.Nom, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();
                }

                // Recherche par region
                Region rechercheRegion = db.Regions.SingleOrDefault(region => region.Nom == location);
                if (rechercheRegion != null)
                {
                    objetsRecherches = objetsRecherches.Where(o => o.proprietaire.Ville.Departement.Region.Nom.IndexOf(rechercheRegion.Nom, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();
                }
                
            }
            return View(objetsRecherches);
        }

     
    }
}
