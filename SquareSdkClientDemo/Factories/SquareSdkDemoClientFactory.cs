using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SquareSdkClientDemo.Clients;
using SquareSdkClientDemo.Extensions;

namespace SquareSdkClientDemo.Factories
{
    public class SquareSdkDemoClientFactory : ISquareSdkDemoClientFactory
    {
        private readonly IServiceProvider serviceProvider;

        public SquareSdkDemoClientFactory(SquareSdkDemoClientFactoryOptions options)
        {
            options = options ?? throw new ArgumentNullException(nameof(options));

            var services = new ServiceCollection();

            if (options.SquareSdkDemoClient != null)
                services.AddSecureClient<ISquareSdkDemoClient, SquareSdkDemoClient>(options.SquareSdkDemoClient);

            serviceProvider = services.BuildServiceProvider();
        }

        public ISquareSdkDemoClient CreateSquareSdkDemoClient()
        {
            return serviceProvider.GetService<ISquareSdkDemoClient>();
        }
    }
}
