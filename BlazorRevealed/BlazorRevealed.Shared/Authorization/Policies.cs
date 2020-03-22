using Microsoft.AspNetCore.Authorization;

namespace BlazorRevealed.Shared.Authorization
{
    public static class Policies
    {
        public const string HasWeather = "HasWeather";
        public const string HasQuotes = "HasQuotes";

        public static AuthorizationPolicy WeatherPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                .RequireClaim(Claims.HasWeather)
                .Build();
        }

        public static AuthorizationPolicy QuotesPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                .RequireClaim(Claims.HasQuotes)
                .Build();
        }
    }
}
