using System;
using System.Security.Claims;
using System.Threading.Tasks;
using BlazorRevealed.Client.Base;
using BlazorRevealed.Client.Data.State;
using BlazorRevealed.Client.Services.I;
using BlazorRevealed.Client.Utility.HttpClients;
using BlazorRevealed.Shared.Authorization;
using BlazorRevealed.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorRevealed.Client.Pages
{
    public class FetchDataPageBase : Page
    {
        public int Claps => State.FetchDataPage.Claps;

        [Inject]
        public ApiClient ApiClient { get; set; }
        public WeatherForecast[] Forecasts { get; set; }

        [Inject]
        public ITestService TestService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var user = await GetUser();

            if (user.HasWeather())
            {
                Forecasts = await ApiClient.GetJsonAsync<WeatherForecast[]>("weather");
            }

            TestService.SaveData(DateTime.Now);
        }

        public void AddClapHandler()
        {
            // call WS to add a clap

            State.FetchDataPage.Claps++;
        }
    }
}