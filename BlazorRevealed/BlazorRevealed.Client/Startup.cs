using System;
using System.Net.Http;
using Autofac;
using BlazorRevealed.Client.Data.State;
using BlazorRevealed.Client.Utility.HttpClients;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorRevealed.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
