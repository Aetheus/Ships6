using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ships6.Models
{
    public class Cruise
    {
        [Key]
        public int CruiseID {get;set;}

        public int OperatorID { get; set; }

        [ForeignKey("OperatorID")]
        public virtual Operator Operator { get; set; }

        public string CruiseName { get; set; }
        public string CruiseDescription { get; set; }
        public byte[] CruiseImage { get; set; }


        [Column(TypeName = "money")]
        public decimal CruisePrice { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CruiseDepartureTime { get; set; }
        
        public int CruiseDayLength { get; set; }
    }
}