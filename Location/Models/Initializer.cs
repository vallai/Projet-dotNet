using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Location.Models
{
    //public class MagasinInitializer : DropCreateDatabaseIfModelChanges<MagasinContext>
    // CreateDatabaseIfNotExists
    // DropCreateDatabaseAlways
    public class Initializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {

        protected override void Seed(ApplicationDbContext context)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)); 

            var userChristian = new ApplicationUser();
            userChristian.UserName = "a@a.fr";
            userChristian.Email = "a@a.fr";
            userChristian.prenom = "Christian";
            userChristian.nom = "SCHMIDT";
            var utilisateur = UserManager.Create(userChristian, "azerty");
            base.Seed(context);

            // Objets
            var objets = new List<Objet>
            {
                new Objet{
                    Titre = "Perceuse béton, bois, métal", 
                    Description = "Perceuse en très bonne état. Mode normal et percution.Tout un lot de forêts à bois, métal et béton est fourni avec un mot expliquant quel foret correspond à quel usage. Mise en garde tout de même, veillez à ne pas l'utiliser pour du béton armé type mur porteur pour ne pas endommager l'appareil." , 
                    Tarif = 10,
                    Caution = 100,
                    proprietaire = userChristian
                },
                new Objet{
                    Titre = "VTT Rockrider 500", 
                    Description = "Suspension fourche avant. Idéal pour les balades tout terrain. Fourni avec antivol", 
                    Tarif = 15,
                    Caution = 200,
                    proprietaire = userChristian
                }
            };

            foreach (var objet in objets)
            {
                context.Objets.Add(objet);
            }

            context.SaveChanges();

        }
    }
}