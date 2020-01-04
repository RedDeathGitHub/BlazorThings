using System;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using BlazorRevealed.Client.Infrastructure;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorRevealed.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            IWebAssemblyHost host = CreateHostBuilder(args).Build();
            await Initialize(host);
            host.Run();
        }
        
        public static IWebAssemblyHostBuilder CreateHostBuilder(string[] args) =>
            BlazorWebAssemblyHost.CreateDefaultBuilder()
                .UseServiceProviderFactory(new AutofacServiceProviderFactory(b => b.RegisterModule<ClientModule>()))
                .UseBlazorStartup<Startup>();

        public static async Task Initialize(IWebAssemblyHost host)
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