using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;

namespace Services.Anonymous
{
    public interface IAnonymousService
    {
        Task<bool> Login(LoginDto loginDto);
        Task<User> GetUserFromLogin(LoginDto loginDto);
        Task Register(RegisterDto registerDto);
    }
}