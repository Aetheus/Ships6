using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ships6.Models
{
    public class Cabin
    {
        [Key]
        public int CabinID { get; set; }
        
        public int CruiseID { get; set; }
        public int CabinTypeID { get; set; }

        [Column(TypeName = "bit")]
        public bool CabinIsOccupied { get; set; }


        [ForeignKey("CruiseID")]
        public virtual Cruise Cruise {get;set;}

        [ForeignKey("CabinTypeID")]
        public virtual CabinType CabinType { get; set; }

    }
}