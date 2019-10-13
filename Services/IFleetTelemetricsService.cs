using RouteMatching.Data.Model;
using RouteMatching.Data.Model.Here;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouteMatching.Services
{
    public interface IFleetTelemetricsService
    {
        IEnumerable<RouteHeaderDTO> GetRoutesMetaData();

        RouteDataDTO GetRouteDetails(string Id);

        MatchRouteResponseDTO TryToMatchRoute(string Id);
    }
}
