using BlazorRevealed.Client.Data.State;
using Microsoft.AspNetCore.Components;

namespace BlazorRevealed.Client.Pages
{
    public class IndexPageBase : ComponentBase
    {
        [Inject]
        public State State { get; set; }

        public int Claps => State.IndexPage.Claps;

        public void AddClapHandler()
        {
            // call WS to add a clap

            State.IndexPage.Claps++;
        }
    }
}