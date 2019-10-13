using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouteMatching.Data.Model;
using RouteMatching.Data.Repositories;

namespace RouteMatching.Services
{
    public class FleetTelemetricsService : IFleetTelemetricsService
    {
        private readonly IRouteRepository routeRepository;

        public FleetTelemetricsService(IRouteRepository routeRepository)
        {
            this.routeRepository = routeRepository;
        }

        public RouteDataDTO GetRouteDetails(string Id)
        {
            return routeRepository.GetRouteData(Id);
        }

        public IEnumerable<RouteHeaderDTO> GetRoutesMetaData()
        {
            return routeRepository.QueryMetadata();
        }
    }
}
