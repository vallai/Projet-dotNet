using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Location.Models
{
    [Table("Reservations")]
    public class Reservation
    {
        public int Id { get; set; }
        public virtual ApplicationUser utilisateur { get; set; }
        public virtual Objet objet { get; set; }
        public DateTime dateDebut { get; set; }
        public DateTime dateFin { get; set; }
    }
}