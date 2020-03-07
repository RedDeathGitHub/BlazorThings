using System;
using System.Threading.Tasks;

namespace BlazorRevealed.Client.Services.I
{
    public interface INotificationService
    {
        event Func<string, int, Task> NotificationReady;
        void Start(int delay, int period);
    }
}
