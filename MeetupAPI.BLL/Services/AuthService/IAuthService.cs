using MeetupAPI.Domain.Entity;

namespace MeetupAPI.BLL.Services.AuthService
{
    public interface IAuthService
    {
        Task<string> Register(User user);
        Task<string> Login(User user);
    }
}
