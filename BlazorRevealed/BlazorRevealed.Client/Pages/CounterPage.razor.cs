using System.Threading.Tasks;
using BlazorRevealed.Client.Data.State;
using Microsoft.AspNetCore.Components;

namespace BlazorRevealed.Client.Pages
{
    public class CounterPageBase : ComponentBase
    {
        [Inject]
        public State State { get; set; }

        public int Claps => State.CounterPage.Claps;

        public async Task AddClapHandler()
        {
            // call WS to add a clap   
            await Task.Yield();
            State.CounterPage.Claps++;
        }
    }
}