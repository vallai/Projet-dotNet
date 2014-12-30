using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Location.Models
{
    [Table("Departements")]
    public class Departement
    {
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public virtual Region Region { get; set; }
    }
}