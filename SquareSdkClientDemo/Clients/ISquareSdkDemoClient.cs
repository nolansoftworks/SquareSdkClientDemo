using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Square.Http.Response;
using SquareSdkClientDemo.Models;

namespace SquareSdkClientDemo.Clients
{
    public interface ISquareSdkDemoClient
    {
        Task<LocationsResponse> GetLocations();
    }
}
