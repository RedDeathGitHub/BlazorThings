using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRevealed.Client.Services
{
    public class TestService: ITestService
    {
        private DateTime data;

        public void SaveData(DateTime date)
        {
            data = date;
        }

        public DateTime GetData()
        {
            return data;
        }
    }
}