using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouteMatching.Data.Model
{
    public class PointDTO
    {
        public int unitId { get; set; }
        public DateTime timedate { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public bool ignition { get; set; }
        public bool engine { get; set; }
        public double speed { get; set; }
        public bool positionError { get; set; }
        public double rpm { get; set; }
        public double direction { get; set; }
        public double distance { get; set; }
    }
}
