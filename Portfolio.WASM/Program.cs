using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Portfolio.WASM.Services;
using Polly.Extensions.Http;
using Polly;

namespace Portfolio.WASM
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            var url = builder.Configuration.GetValue<string>("BaseUrl");


            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            //builder.Services.AddOidcAuthentication(options =>
            //{
            //    builder.Configuration.Bind("Auth0", options.ProviderOptions);
            //    options.ProviderOptions.ResponseType = "code";
            //});

            var jitterer = new Random();
            var retryPolicy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                                                    + TimeSpan.FromMilliseconds(jitterer.Next(0, 100)));

            builder.Services.AddHttpClient<IProjectDataService, APIProjectDataService>(client => client.BaseAddress = new Uri(url))
                .SetHandlerLifetime(TimeSpan.FromSeconds(10))
                .AddPolicyHandler(retryPolicy);
            
            

            await builder.Build().RunAsync();
        }
    }
}
