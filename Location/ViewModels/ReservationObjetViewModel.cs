using Location.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Location.ViewModels
{
    public class ReservationObjetViewModel
    {
        public Objet objet { get; set; }
        public IEnumerable<Reservation> reservations { get; set; }
    }
}