using System.Threading.Tasks;
using BlazorRevealed.Shared.Models;

namespace BlazorRevealed.Client.Services.I
{
    public interface IAuthService
    {
        Task<LoginResult> Login(Login login);
        Task Logout();
        Task<RegistrationResult> Register(Registration registration);
        Task Update();
    }
}
