using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using Square.Http.Response;
using SquareSdkClientDemo.Models;

namespace SquareSdkClientDemo.Clients
{
    public class SquareSdkDemoClient : ISquareSdkDemoClient
    {
        private HttpClient httpClient;

        public SquareSdkDemoClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<LocationsResponse> GetLocations()
        {
            try
            {
                var uriPath = $@"{httpClient.BaseAddress}v2/locations";

                var httpResponse = await httpClient.GetAsync(uriPath);

                if (httpResponse.StatusCode != HttpStatusCode.OK)
                {
                    Log.Error("The request to Get Locations was not successful");
                }

                var responseBody = await httpResponse.Content.ReadAsStringAsync();

                var response = JsonConvert.DeserializeObject<LocationsResponse>(responseBody);

                return response;
            }
            catch (Exception ex)
            {
                Log.Error(ex, nameof(GetLocations));
                throw;
            }
        }
    }
}
