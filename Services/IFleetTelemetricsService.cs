using RouteMatching.Data.Model;
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
    }
}
