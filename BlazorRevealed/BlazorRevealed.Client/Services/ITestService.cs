using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRevealed.Client.Services
{
    public interface ITestService
    {
        void SaveData(DateTime data);
        DateTime GetData();
    }
}
