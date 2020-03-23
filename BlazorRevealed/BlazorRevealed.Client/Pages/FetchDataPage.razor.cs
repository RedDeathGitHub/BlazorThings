using System;
using System.Threading.Tasks;
using BlazorRevealed.Client.Base;
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

        [Inject]
        public ITestService TestService { get; set; }

        public WeatherForecast[] Forecasts { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var hasWeather = await CheckPolicy(Policies.HasWeather);

            if (hasWeather)
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