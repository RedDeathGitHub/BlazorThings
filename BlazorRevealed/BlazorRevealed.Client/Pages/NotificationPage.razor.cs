using System;
using System.Threading.Tasks;
using BlazorRevealed.Client.Base;
using BlazorRevealed.Client.Data.State;
using BlazorRevealed.Client.Services;
using BlazorRevealed.Client.Services.I;
using Microsoft.AspNetCore.Components;

namespace BlazorRevealed.Client.Pages
{
    public class NotificationPageBase : Page, IDisposable
    {
        [Inject]
        public INotificationService NotificationService { get; set; }
        
        protected (string key, int value) LastNotification;

        protected override void OnInitialized()
        {
            NotificationService.NotificationReady += OnNotificationReady;
        }

        public async Task OnNotificationReady(string key, int value)
        {
            await InvokeAsync(() =>
            {
                LastNotification = (key, value);
                StateHasChanged();
            });
        }

        public void Dispose()
        {
            NotificationService.NotificationReady -= OnNotificationReady;
        }
    }
}