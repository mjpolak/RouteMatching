using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RouteMatching.Data.Model;
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
        [HttpGet]
        public IEnumerable<RouteHeaderDTO> Get()
        {
            return fleetTelemetrics.GetRoutesMetaData();
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<PointDTO>> Get(string id)
        {
            return fleetTelemetrics.GetRouteDetails(id)?.Points ?? (ActionResult<IEnumerable<PointDTO>>)NotFound();
        }
        [HttpGet("routematching/{id}")]
        public ActionResult<IEnumerable<PointDTO>> FindRouteMatching(string id)
        {
            return fleetTelemetrics.GetRouteDetails(id)?.Points ?? (ActionResult<IEnumerable<PointDTO>>)NotFound();
        }
    }
}
