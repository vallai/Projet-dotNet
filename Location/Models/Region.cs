using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Location.Models
{
    [Table("Regions")]
    public class Region
    {
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
    }
}