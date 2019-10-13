using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouteMatching.Data.Model
{
    public class WarningsDTO
    {
        public int category { get; set; }
        public int routeLinkSeqNum { get; set; }
        public int tracePointSeqNum { get; set; }
        public string text { get; set; }
    }
}
