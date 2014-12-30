using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Location.Models
{
    [Table("Villes")]
    public class Ville
    {
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public int Code_postal { get; set; }
        [Required]
        public virtual Departement Departement { get; set; }
    }
}