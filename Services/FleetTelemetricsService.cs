using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using RouteMatching.Data.Model;
using RouteMatching.Data.Model.Here;
using RouteMatching.Data.Repositories;

namespace RouteMatching.Services
{
    public class FleetTelemetricsService : IFleetTelemetricsService
    {
        private readonly IRouteRepository routeRepository;
        private readonly Serilog.ILogger logger;
        private readonly IConfiguration configuration;
        private readonly string ApiId;
        private readonly string ApiCode;

        public FleetTelemetricsService(IRouteRepository routeRepository,Serilog.ILogger logger,IConfiguration configuration)
        {
            this.routeRepository = routeRepository;
            var hereApi = configuration.GetSection("HereApi");
            ApiId = hereApi["app_id"];
            ApiCode = hereApi["app_code"];
            this.logger = logger;
            this.configuration = configuration;
        }

        public RouteDataDTO GetRouteDetails(string Id)
        {
            return routeRepository.GetRouteData(Id);
        }

        public IEnumerable<RouteHeaderDTO> GetRoutesMetaData()
        {
            return routeRepository.QueryMetadata();
        }

        public MatchRouteResponseDTO TryToMatchRoute(string Id)
        {
            var data = routeRepository.GetRouteData(Id);
            if (data == null)
            {
                return null;
            }
            var gpxData = SerializeToHereFormat(data);


            var client = new RestClient("https://rme.api.here.com/2/matchroute.json");
            var request = new RestRequest(Method.GET);
            request.AddParameter("app_id", ApiId);
            request.AddParameter("app_code", ApiCode);
            request.AddParameter("routemode", "car");
            request.AddParameter("file", gpxData);

            var result = client.Execute(request);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<MatchRouteResponseDTO>(result.Content);
            }
            return null;
        }

        protected string SerializeToHereFormat(RouteDataDTO route)
        {
            var gpx = new gpxType();

            gpx.trk = new trkType[1];
            var trk = gpx.trk[0] = new trkType();

            trk.trkseg = new trksegType[1];
            var seg = trk.trkseg[0] = new trksegType();

            seg.trkpt = route.Points.Select(x => new wptType()
            {
                lat = x.latitude,
                lon = x.longitude
            }).ToArray();


            XmlSerializerNamespaces ns = new XmlSerializerNamespaces(); ns.Add("", "");

            var serializer = new XmlSerializer(gpx.GetType());
            using (StringWriter textWriter = new StringWriter())
            using(XmlWriter writer = XmlWriter.Create(textWriter, new XmlWriterSettings { OmitXmlDeclaration = true }))
            {

                serializer.Serialize(writer, gpx);
                var str = textWriter.ToString();
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(str);
                return System.Convert.ToBase64String(plainTextBytes);
            }
        }
    }
}
