using System.Threading.Tasks;
using BlazorRevealed.Client.Base;
using BlazorRevealed.Client.Data.State;
using Microsoft.AspNetCore.Components;

namespace BlazorRevealed.Client.Pages
{
    public class CounterPageBase : Page
    {
        public int Claps => State.CounterPage.Claps;

        public async Task AddClapHandler()
        {
            // call WS to add a clap   
            await Task.Yield();
            State.CounterPage.Claps++;
        }
    }
}