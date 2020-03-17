using System;
using System.Net.Http;
using Autofac;
using Blazored.LocalStorage;
using BlazorRevealed.Client.Data.State;
using BlazorRevealed.Client.Utility.HttpClients;
using FluentScheduler;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorRevealed.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBlazoredLocalStorage();
            services.AddAuthorizationCore();

            JobManager.UseUtcTime();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
