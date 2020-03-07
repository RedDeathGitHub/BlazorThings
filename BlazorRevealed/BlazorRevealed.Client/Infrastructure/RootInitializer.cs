using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorRevealed.Client.Data.State;
using BlazorRevealed.Client.Services;
using BlazorRevealed.Client.Services.I;
using BlazorRevealed.Client.Utility.HttpClients;
using BlazorRevealed.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorRevealed.Client.Infrastructure
{
    public class RootInitializer
    {
        private readonly INotificationService notificationService;
        private readonly ApiClient apiClient;
        private readonly State state;

        public RootInitializer(INotificationService notificationService, ApiClient apiClient, State state)
        {
            Console.WriteLine("RootInitializer.Start");
            this.notificationService = notificationService;
            this.apiClient = apiClient;
            this.state = state;
        }

        public async Task Initialize()
        {
            Console.WriteLine("RootInitializer.Initialize");

            var configuration = await GetConfiguration();
            state.Configuration = configuration;

            notificationService.Start(configuration.NotificationDelay, configuration.NotificationPeriod);
        }

        private async Task<Configuration> GetConfiguration()
        {
            Console.WriteLine("RootInitializer.GetConfiguration");

            // TODO: in the next version this will work!
            // https://github.com/aspnet/AspNetCore/issues/18104

            //var configuration = await apiClient.GetJsonAsync<Configuration>("configuration");

            // TODO: get footer from API, add to state, display as MarkupString (CMS simulation)

            //if (configuration.NotificationDelay <= 0)
            //{
            return new Configuration
                {
                    NotificationDelay = 5000,
                    NotificationPeriod = 2000
                };
            //}

            //return configuration;
        }
    }
}
