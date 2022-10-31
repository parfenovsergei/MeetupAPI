using MeetupAPI.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetupAPI.BLL.Services.AuthService
{
    public interface IAuthService
    {
        Task<string> Register(User user);
        Task<string> Login(User user);
    }
}
