using System;
using System.Net.Http;

namespace BlazorRevealed.Client.Utility.HttpClients
{
    public class ApiClient : HttpClient
    {
        public ApiClient()
        {
            BaseAddress = new Uri("https://localhost:44341/api/");
        }
    }
}
