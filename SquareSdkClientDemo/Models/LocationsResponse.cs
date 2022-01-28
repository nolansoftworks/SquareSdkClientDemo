using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Square.Models;

namespace SquareSdkClientDemo.Models
{
    public class LocationsResponse
    {
        [JsonProperty("locations")]
        public List<Location> Locations { get; set; }
    }
}
