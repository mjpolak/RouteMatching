using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RouteMatching.Data.Model;
using RouteMatching.Data.Model.Here;
using RouteMatching.Services;

namespace RouteMatching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FleetTelemetricsController : ControllerBase
    {
        private readonly IFleetTelemetricsService fleetTelemetrics;

        public FleetTelemetricsController(IFleetTelemetricsService fleetTelemetrics)
        {
            this.fleetTelemetrics = fleetTelemetrics;
        }
        /// <summary>
        /// Returns List of routes stored in repository
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<RouteHeaderDTO> Get()
        {
            return fleetTelemetrics.GetRoutesMetaData();
        }
        /// <summary>
        /// Returns List of points for given route
        /// </summary>
        /// <param name="id">Route id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<PointDTO>> Get(string id)
        {
            return fleetTelemetrics.GetRouteDetails(id)?.Points ?? (ActionResult<IEnumerable<PointDTO>>)NotFound();
        }
        /// <summary>
        /// Uses HERE api to find matching route for given points
        /// </summary>
        /// <param name="id">Route id</param>
        /// <returns></returns>
        [HttpGet("routematching/{id}")]
        public ActionResult<MatchRouteResponseDTO> FindRouteMatching(string id)
        {
            return fleetTelemetrics.TryToMatchRoute(id) ?? (ActionResult<MatchRouteResponseDTO>)NotFound();
        }
    }
}
