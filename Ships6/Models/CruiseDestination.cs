using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ships6.Models
{
    public class CruiseDestination
    {
        [Key]
        [Column(Order = 0)]
        public int CruiseID { get; set; }

        [Key]
        [Column(Order = 1)]
        public int DestinationID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int tripOrder { get; set; }

        [ForeignKey("CruiseID")]
        public virtual Cruise Cruise { get; set; }

        [ForeignKey("DestinationID")]
        public virtual Destination Destination { get; set; }
    }
}