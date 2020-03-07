using System;

namespace BlazorRevealed.Client.Services.I
{
    public interface ITestService
    {
        void SaveData(DateTime data);
        DateTime GetData();
    }
}
