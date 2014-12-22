using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
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


            // Categories

            var categorieBricolage = new Categorie { Nom = "Bricolage" };
            var categorieLoisirs = new Categorie { Nom = "Loisirs" };
            var categories = new List<Categorie>
            {
                new Categorie{
                    Nom = "Véhicules"
                },
                new Categorie{
                    Nom = "Événements"
                },
                new Categorie{
                    Nom = "High Tech"
                },
                new Categorie{
                    Nom = "Maison"
                },
                new Categorie{
                    Nom = "Vacances"
                }
            };

            foreach (var categorie in categories)
            {
                context.Categories.Add(categorie);
            }
            context.Categories.Add(categorieBricolage);
            context.Categories.Add(categorieLoisirs);

            // Objets

            var objets = new List<Objet>
            {
                new Objet{
                    Titre = "Perceuse béton, bois, métal", 
                    Description = "Perceuse en très bonne état. Mode normal et percution.Tout un lot de forêts à bois, métal et béton est fourni avec un mot expliquant quel foret correspond à quel usage. Mise en garde tout de même, veillez à ne pas l'utiliser pour du béton armé type mur porteur pour ne pas endommager l'appareil." , 
                    Categorie = categorieBricolage,
                    Tarif = 10,
                    Caution = 100,
                    proprietaire = userChristian
                },
                new Objet{
                    Titre = "VTT Rockrider 500", 
                    Description = "Suspension fourche avant. Idéal pour les balades tout terrain. Fourni avec antivol", 
                    Categorie = categorieLoisirs,
                    Tarif = 15,
                    Caution = 200,
                    proprietaire = userChristian
                }
            };

            foreach (var objet in objets)
            {
                context.Objets.Add(objet);
            }

  
            string toto = "";
try{
            context.SaveChanges();
}
catch (DbEntityValidationException e)
{
    foreach (var eve in e.EntityValidationErrors)
    {
        toto += "Entity of type \"" + eve.Entry.Entity.GetType().Name + "\" in state \"" + eve.Entry.State + "\" has the following validation errors:";
        foreach (var ve in eve.ValidationErrors)
        {
            toto += "- Property: \"" + ve.PropertyName + "\", Error: \"" + ve.ErrorMessage + "\"";
        }
    }
}


        }
    }
}