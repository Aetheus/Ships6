using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ships6.Models
{
    public class CabinType
    {
        [Key]
        public int CabinTypeID { get; set; }


        [Display(Name = "Cabin Type Name")]
        public string CabinTypeName { get; set; }
        
        [Display (Name="Price")]
        [Column(TypeName = "money")]
        public decimal CabinTypePrice { get; set; }
    }
}