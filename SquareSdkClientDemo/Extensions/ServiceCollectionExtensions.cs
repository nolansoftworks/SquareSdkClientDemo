using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SquareSdkClientDemo.Authorization;
using SquareSdkClientDemo.Factories;

namespace SquareSdkClientDemo.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSecureClient<TClient, TImplementation>(this IServiceCollection services, ClientOptions options) 
            where TClient : class 
            where TImplementation : class, TClient
        {
            options = options ?? throw new ArgumentNullException(nameof(options));

            services
                .AddHttpClient<TClient, TImplementation>(client =>
                {
                    client.BaseAddress = new Uri(options.BaseUrl);
                    client.DefaultRequestHeaders.Add("Square-Version", "2022-01-20");
                    client.DefaultRequestHeaders.Add("Authorization", $@"Bearer {options.ApiKey}");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                });

            return services;
        }

        public static IServiceCollection AddSquareSdkDemoClientFactory(this IServiceCollection services,
            SquareSdkDemoClientFactoryOptions options)
        {
            options = options ?? throw new ArgumentNullException(nameof(options));

            services
                .AddSingleton(options)
                .AddSingleton<ISquareSdkDemoClientFactory, SquareSdkDemoClientFactory>();

            return services;
        }

        public static IServiceCollection AddSquareSdkDemoClientFactory(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetSection(nameof(SquareSdkDemoClientFactoryOptions))
                .Get<SquareSdkDemoClientFactoryOptions>();

            return services.AddSquareSdkDemoClientFactory(options);
        }
    }
}
