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

        public int CruiseID { get; set; }
        public int UserID { get; set; }
        public int CabinID { get; set; }

        [Column(TypeName="datetime2")]
        public DateTime ReservationTime { get; set; }

        [ForeignKey("CruiseID")]
        public Cruise Cruise;

        [ForeignKey("UserID")]
        public ApplicationUser ApplicationUser;

        [ForeignKey("CabinID")]
        public Cabin Cabin;
    }
}