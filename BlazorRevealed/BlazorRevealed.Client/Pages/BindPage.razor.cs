using System;
using BlazorRevealed.Client.Base;
using BlazorRevealed.Client.Data.State;
using Microsoft.AspNetCore.Components;

namespace BlazorRevealed.Client.Pages
{
    public class BindPageBase : Page
    {
        public int Year { get; set; } = 2000;

        public string Message { get; set; }

        private readonly Random random = new Random();

        protected void ChangeTheYear()
        {
            Year = random.Next(2020);
        }

        protected void OnYearChanged(int year)
        {
            Message = $"Previous year was {Year} and new one is {year}";
        }
    }
}