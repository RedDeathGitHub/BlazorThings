using System.Security.Claims;

namespace BlazorRevealed.Shared.Authorization
{
    public static class AuthorizationUtility
    {
        public static bool HasWeather(this ClaimsPrincipal user)
        {
            return user.HasClaim(Claims.HasWeather, bool.TrueString);
        }
    }
}
