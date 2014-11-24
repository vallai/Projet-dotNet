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

            var appUser = new ApplicationUser();
            appUser.UserName = "a@a.fr";
            appUser.Email = "a@a.fr";
            appUser.prenom = "Christian";
            appUser.nom = "SCHMIDT";
            var utilisateur = UserManager.Create(appUser, "azerty");
            base.Seed(context);


            context.SaveChanges();

        }
    }
}