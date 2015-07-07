using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Ships6.Models
{
    public class Operator
    {
        [Key]
        public int OperatorID { get; set; }

        [Display (Name="Operator Name")]
        public string OperatorName { get; set; }
    }
}