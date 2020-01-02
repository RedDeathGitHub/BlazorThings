using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRevealed.Client.Services
{
    public interface INotificationService
    {
        event Func<string, int, Task> NotificationReady;
        void Start(int delay, int period);
    }
}
