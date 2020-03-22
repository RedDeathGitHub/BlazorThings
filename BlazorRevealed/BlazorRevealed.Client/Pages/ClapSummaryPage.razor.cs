using System;
using System.Collections.Generic;
using BlazorRevealed.Client.Base;
using BlazorRevealed.Client.Data;
using BlazorRevealed.Client.Data.Models;
using BlazorRevealed.Client.Data.State;
using BlazorRevealed.Client.Services;
using BlazorRevealed.Client.Services.I;
using Microsoft.AspNetCore.Components;

namespace BlazorRevealed.Client.Pages
{
    public class ClapSummaryPageBase : Page
    {
        [Inject]
        public ITestService TestService { get; set; }

        public DateTime WeatherDate => TestService.GetData();

        public List<PageWithClaps> Pages => new List<PageWithClaps>
        {
            new PageWithClaps
            {
                Name = nameof(State.IndexPage),
                Link = "/",
                Claps = State.IndexPage.Claps
            },
            new PageWithClaps
            {
                Name = nameof(State.CounterPage),
                Link = "/counter",
                Claps = State.CounterPage.Claps
            },
            new PageWithClaps
            {
                Name = nameof(State.FetchDataPage),
                Link = "/fetch-data",
                Claps = State.FetchDataPage.Claps
            }
        };
    }
}