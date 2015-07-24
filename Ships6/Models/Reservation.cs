using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ships6.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }

        public int? CruiseID { get; set; }
        public string UserID { get; set; }
        public int? CabinID { get; set; }

        [Display (Name="Booked On")]
        [Column(TypeName="datetime2")]
        public DateTime ReservationTime { get; set; }

        [Display(Name = "Booking Price")]
        [Column(TypeName = "money")]
        public decimal ReservationPrice { get; set; }


        [ForeignKey("CruiseID")]
        public virtual Cruise Cruise{get;set;}

        [ForeignKey("UserID")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        
        [ForeignKey("CabinID")]
        public virtual Cabin Cabin { get; set; }
    }
}