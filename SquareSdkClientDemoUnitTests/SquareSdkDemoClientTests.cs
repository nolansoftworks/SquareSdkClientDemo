using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SquareSdkClientDemo.Authorization;
using SquareSdkClientDemo.Clients;
using SquareSdkClientDemo.Extensions;

namespace SquareSdkClientDemoUnitTests
{
    [TestClass]
    public class SquareSdkDemoClientTests
    {
        private static SquareSdkDemoClient client;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var options = configuration
                .GetSection(nameof(SquareSdkDemoClient))
                .Get<ClientOptions>();

            var serviceProvider = new ServiceCollection()
                .AddSecureClient<ISquareSdkDemoClient, SquareSdkDemoClient>(options)
                .BuildServiceProvider();

            client = serviceProvider.GetRequiredService<ISquareSdkDemoClient>() as SquareSdkDemoClient;
        }

        [TestMethod]
        public async Task AValidBusinessWithSquarePayment_WithValidRequest_ReturnsLocations()
        {
            var response = await client.GetLocations();

            Assert.IsNotNull(response);
        }
    }
}