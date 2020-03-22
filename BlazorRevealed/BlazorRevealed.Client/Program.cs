using System;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Blazored.LocalStorage;
using BlazorRevealed.Client.Infrastructure;
using BlazorRevealed.Shared.Authorization;
using FluentScheduler;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


namespace BlazorRevealed.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebAssemblyHost host = CreateHostBuilder(args).Build();
            await Initialize(host);
            await host.RunAsync();
        }

        public static WebAssemblyHostBuilder CreateHostBuilder(string[] args)
        {
            var builder =  WebAssemblyHostBuilder.CreateDefault();
            builder.RootComponents.Add<App>("app");

            var factory = new AutofacServiceProviderFactory(b => b.RegisterModule<ClientModule>());
            builder.ConfigureContainer(factory);
            
            var services = builder.Services;
            services.AddOptions();
            services.AddBlazoredLocalStorage();

            services.AddAuthorizationCore(config =>
            {
                config.AddPolicy(Policies.HasWeather, Policies.WeatherPolicy());
                config.AddPolicy(Policies.HasQuotes, Policies.QuotesPolicy());
            });

            JobManager.UseUtcTime();

            return builder;
        }

        public static async Task Initialize(WebAssemblyHost host)
        {
            Console.WriteLine("Start Initialize");
            var rootInitializer = host.Services.GetService<RootInitializer>();

            if (rootInitializer == null)
            {
                throw new InvalidOperationException("The RootInitializer service isn't registered.");
            }

            Console.WriteLine("Initializing");
            await rootInitializer.Initialize();
        }
    }
}