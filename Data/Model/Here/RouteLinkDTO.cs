using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouteMatching.Data.Model
{
    public class RouteLinkDTO
    {
        public int linkId { get; set; }
        public int functionalClass { get; set; }

        public float confidence { get; set; }
        public string shape { get; set; }


        public float offset { get; set; }
        public int mSecToReachLinkFromStart { get; set; }
        public float linkLength { get; set; }
    }
}
