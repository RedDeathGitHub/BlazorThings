using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorRevealed.Client.Data.State;
using BlazorRevealed.Client.Services;
using BlazorRevealed.Client.Utility.HttpClients;
using BlazorRevealed.Shared.Dto;
using Microsoft.AspNetCore.Components;

namespace BlazorRevealed.Client.Pages
{
    public class FetchDataPageBase : ComponentBase
    {
        [Inject]
        public State State { get; set; }
        public int Claps => State.FetchDataPage.Claps;

        [Inject]
        public ApiClient ApiClient { get; set; }
        public WeatherForecastDto[] Forecasts { get; set; }

        [Inject]
        public ITestService TestService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Forecasts = await ApiClient.GetJsonAsync<WeatherForecastDto[]>("weather");
            TestService.SaveData(DateTime.Now);
        }

        public void AddClapHandler()
        {
            // call WS to add a clap

            State.FetchDataPage.Claps++;
        }
    }
}