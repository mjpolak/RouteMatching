using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouteMatching.Data.Model
{
    public class RouteDataDTO : RouteHeaderDTO
    {
        public List<PointDTO> Points { get; set; }
    }
}
