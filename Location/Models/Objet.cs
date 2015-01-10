using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Location.Models
{
    [Table("Objets")]
    public class Objet
    {
        public int Id { get; set; }
        [Required]
        public string Titre { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "Catégorie")]
        public virtual Categorie Categorie { get; set; }
        [Required]
        public float Tarif { get; set; }
        [Required]
        public float Caution { get; set; }
        [ScaffoldColumn(false)]
        public virtual ApplicationUser proprietaire { get; set; }
    }
}