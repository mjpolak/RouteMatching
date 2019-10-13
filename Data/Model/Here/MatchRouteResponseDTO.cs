using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouteMatching.Data.Model.Here
{
    public class MatchRouteResponseDTO
    {
        public List<RouteLinkDTO> RouteLinks { get; set; }
        public List<TracePointsDTO> TracePoints { get; set; }
        public List<WarningsDTO> Warnings { get; set; }
    }
}
