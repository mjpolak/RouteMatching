using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RouteMatching.Data.Model;

namespace RouteMatching.Data.Repositories
{
    public class RouteRepository : IRouteRepository
    {
        protected readonly string routesDirectorPath;

        public RouteRepository(IHostingEnvironment hostingEnvironment)
        {
            routesDirectorPath = Path.Combine(hostingEnvironment.ContentRootPath, @"App_Data/Routes");
        }

        public RouteDataDTO GetRouteData(string Id)
        {
            var filePath = Path.Combine(routesDirectorPath, $"{Id}.json");
            if (File.Exists(filePath))
            {

                var data = JsonConvert.DeserializeObject<List<PointDTO>>(File.ReadAllText(filePath));
                return new RouteDataDTO()
                {
                    Points = data,
                    Id=Id
                };
            }
            return null;
        }

        public IEnumerable<RouteHeaderDTO> QueryMetadata()
        {

            return Directory.GetFiles(routesDirectorPath)
                            .Select(Path.GetFileNameWithoutExtension)
                            .Select(file => new RouteHeaderDTO()
                            {
                                Id=file
                            });
        }
    }
}
