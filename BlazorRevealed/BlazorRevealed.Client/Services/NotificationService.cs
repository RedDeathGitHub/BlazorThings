using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorRevealed.Client.Services
{
    public class NotificationService : INotificationService
    {
        private Timer timer;

        public void Start(int delay, int period)
        {
            if (period <= 0)
            {
                throw new ApplicationException("Notification period must be greater than 0.");
            }

            timer = new Timer(HandleTimerCallback, null, delay, period);
        }

        private async void HandleTimerCallback(object state)
        {
            var key = Guid.NewGuid().ToString();
            var value = new Random().Next();

            await OnNotificationReady(key, value);
        }
        
        private async Task OnNotificationReady(string key, int value)
        {
            if (NotificationReady != null)
            {
                await NotificationReady?.Invoke(key, value);
            }
        }

        public event Func<string, int, Task> NotificationReady;
    }
}
