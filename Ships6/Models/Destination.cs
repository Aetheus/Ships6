using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Ships6.Models
{
    public class Destination
    {
        [Key]
        public int DestinationID { get; set; }

        [Display(Name = "Destination Name")]
        public string DestinationName { get; set; }

        [Display(Name = "Country")]
        public string DestinationCountry { get; set; }

        [Display(Name = "Image")]
        public byte[] DestinationImage { get; set; }
    }


    /*public class DestinationCreateViewModel
    {
        public int DestinationName { get; set; }
        public string DestinationCountry { get; set; }
        public HttpPostedFile DestinationImage { get; set; }
    }*/
}