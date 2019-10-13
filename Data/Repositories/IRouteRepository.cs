using RouteMatching.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouteMatching.Data.Repositories
{
    public interface IRouteRepository
    {
        IEnumerable<RouteHeaderDTO> QueryMetadata();
        RouteDataDTO GetRouteData(string Id);
    }
}
