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

        [Display (Name="Cruise Name")]
        public string CruiseName { get; set; }

        [Display (Name="Description")]
        public string CruiseDescription { get; set; }

        [Display(Name = "Image")]
        public byte[] CruiseImage { get; set; }


        [Display(Name = "Price")]
        [Column(TypeName = "money")]
        public decimal CruisePrice { get; set; }

        [Display(Name = "Departure Time")]
        [Column(TypeName = "datetime2")]
        public DateTime CruiseDepartureTime { get; set; }
        
        public int CruiseDayLength { get; set; }
    }
}