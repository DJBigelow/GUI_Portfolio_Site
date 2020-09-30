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

namespace Portfolio.WASM
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            var url = builder.Configuration.GetValue<string>("BaseUrl");

            builder.Services.AddHttpClient<IProjectDataService, APIProjectDataService>(client => client.BaseAddress = new Uri(url));
            

            await builder.Build().RunAsync();
        }
    }
}
