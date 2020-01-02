using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorRevealed.Client.Data.State;
using BlazorRevealed.Client.Services;
using BlazorRevealed.Client.Utility.HttpClients;
using BlazorRevealed.Shared.Dto;
using Microsoft.AspNetCore.Components;

namespace BlazorRevealed.Client.Infrastructure
{
    public class RootInitializer
    {
        private readonly INotificationService notificationService;
        private readonly ApiClient apiClient;
        private readonly State state;

        //public RootInitializer(INotificationService notificationService)
        //{
        //    Console.WriteLine("RootInitializer.Start");
        //    this.notificationService = notificationService;

        //    new HttpClient();
        //    //this.apiClient = apiClient;
        //    //this.state = state;
        //}

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
            //var configuration = await apiClient.GetJsonAsync<Configuration>("configuration");
            //return configuration ?? new Configuration();

            return  new Configuration()
            {
                NotificationDelay = 5000,
                NotificationPeriod = 2000
            };
        }
    }
}
