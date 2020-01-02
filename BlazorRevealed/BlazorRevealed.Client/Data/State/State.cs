using BlazorRevealed.Shared.Dto;

namespace BlazorRevealed.Client.Data.State
{
    public class State
    {
        public State()
        {
            Configuration = new Configuration();
            CounterPage = new CounterPageState();
            IndexPage = new IndexPageState();
            FetchDataPage = new FetchDataPageState();
        }

        public Configuration Configuration { get; set; }
        public CounterPageState CounterPage { get; set; }
        public IndexPageState IndexPage { get; set; }
        public FetchDataPageState FetchDataPage { get; set; }
    }
}
