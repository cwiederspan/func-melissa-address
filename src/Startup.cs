using System.Net.Http;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(MyFunctions.Startup))]

namespace MyFunctions {

    public class Startup : FunctionsStartup {

        public override void Configure(IFunctionsHostBuilder builder) {

            System.Diagnostics.Debug.WriteLine("Startup is executing...");

            builder.Services.AddHttpClient();

            // builder.Services.AddSingleton<IAddressCleaner, MockAddressCleaner>();
            builder.Services.AddSingleton<IAddressCleaner, MelissaAddressCleaner>();

            // builder.Services.AddSingleton<ILoggerProvider, MyLoggerProvider>();
        }
    }
}