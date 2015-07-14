using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ships6.Models
{
    public class CruiseCompareViewModel
    {
        public List<Cruise> cruiseList { get; set; }
        public Dictionary<int, List<Destination>> cruiseDestinationsDictionary { get; set; }

        public CruiseCompareViewModel(List<Cruise> cruiseList, Dictionary<int, List<Destination>> cruiseDestinationsDictionary)
        {
            this.cruiseList = cruiseList;
            this.cruiseDestinationsDictionary = cruiseDestinationsDictionary;
        }
    }
}