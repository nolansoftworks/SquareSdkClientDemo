using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SquareSdkClientDemo.Authorization;
using SquareSdkClientDemo.Clients;

namespace SquareSdkClientDemo.Factories
{
    public interface ISquareSdkDemoClientFactory
    {
        ISquareSdkDemoClient CreateSquareSdkDemoClient();
    }
}
