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
    //public class Initializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    // CreateDatabaseIfNotExists
    // DropCreateDatabaseAlways
    public class Initializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {

        protected override void Seed(ApplicationDbContext context)
        {
            // CATEGORIES

            var categorieBricolage = new Categorie { Nom = "Bricolage" };
            var categorieLoisirs = new Categorie { Nom = "Loisirs" };
            var categorieEvenements = new Categorie { Nom = "Événements" };
            var categories = new List<Categorie>
            {
                new Categorie{
                    Nom = "Véhicules"
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
            context.Categories.Add(categorieEvenements);
            context.Categories.Add(categorieBricolage);
            context.Categories.Add(categorieLoisirs);
           
            // REGIONS

            var rhoneAlpes = new Region { Nom = "Rhone-Alpes" };
            context.Regions.Add(rhoneAlpes);

            var lorraine = new Region { Nom = "Lorraine" };
            context.Regions.Add(lorraine);

            // DEPARTEMENTS

            var ain = new Departement
            {
                Nom = "Ain",
                Numero = 1,
                Region = rhoneAlpes
            };

            var rhone = new Departement
            {
                Nom = "Rhone",
                Numero = 69,
                Region = rhoneAlpes
            };

            var isere = new Departement
            {
                Nom = "Isère",
                Numero = 38,
                Region = rhoneAlpes
            };

            context.Departements.Add(ain);
            context.Departements.Add(rhone);
            context.Departements.Add(isere);

            // VILLES

            var grenoble = new Ville
            {
                Nom = "Grenoble",
                Code_postal = 38000,
                Departement = isere
            };

            var lyon = new Ville
            {
                Nom = "Lyon",
                Code_postal = 69000,
                Departement = rhone
            };

            context.Villes.Add(grenoble);
            context.Villes.Add(lyon);

            // UTILISATEUR
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var userChristian = new ApplicationUser();
            userChristian.UserName = "a@a.fr";
            userChristian.Email = "a@a.fr";
            userChristian.prenom = "Christian";
            userChristian.nom = "SCHMIDT";
            userChristian.Ville = grenoble;
            var utilisateur = UserManager.Create(userChristian, "azerty");
            base.Seed(context);

            // OBJETS

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
                },
                new Objet{
                    Titre = "ObjetEvenement", 
                    Description = "Super description Super description Super description", 
                    Categorie = categorieEvenements,
                    Tarif = 10,
                    Caution = 100,
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