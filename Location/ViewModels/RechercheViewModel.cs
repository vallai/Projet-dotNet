using Location.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Location.ViewModels
{
    public class RechercheViewModel
    {
        public IEnumerable<Objet> objets { get; set; }
        public IEnumerable<Categorie> categories { get; set; }
        public String keyword { get; set; }
        public String location { get; set; }
        public Categorie categorie { get; set; }
    }
}