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

        // GET: Ville
        public ActionResult Index(String recherche)
        {
            List<Ville> villesRecherchees = new List<Ville>();
            if (!string.IsNullOrWhiteSpace(recherche))
            {
                villesRecherchees = db.Villes.ToList().Where(v => v.Nom.IndexOf(recherche, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();
            }

            return new JsonResult { Data = (villesRecherchees), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
