using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouteMatching.Data.Model
{
    public class TracePointsDTO
    {
        public float lat { get; set; }
        public float lon { get; set; }
        public float elevation { get; set; }
        public float speedMps { get; set; }
        public float headingDegreeNorthClockwise { get; set; }
        public float latMatched { get; set; }
        public float lonMatched { get; set; }
        public int linkIdMatched { get; set; }
        public int routeLinkSeqNrMatched { get; set; }
        public int timestamp { get; set; }
        public float matchDistance { get; set; }
        public float headingMatched { get; set; }
        public float minError { get; set; }
        public float confidenceValue { get; set; }
        public float matchOffsetOnLink { get; set; }
    }
}
