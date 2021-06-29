using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Services.Anonymous
{
    public class AnonymousService : IAnonymousService
    {
        private readonly IAppDbContext _dbContext;

        public AnonymousService(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Login(LoginDto loginDto)
        {
            var account = await _dbContext.Users.FirstOrDefaultAsync(x => x.Login == loginDto.Login);
            if (account.Password == loginDto.Password)
                return true;
            return false;
        }

        public async Task<User> GetUserFromLogin(LoginDto loginDto)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Login == loginDto.Login);
        }
        
        public async Task Register(RegisterDto registerDto)
        {
            var user = new User()
            {
                Login = registerDto.Login,
                Password = registerDto.Password,
                Roles = registerDto.Roles,
                AccountBalance = 1000
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }
    }

    public class LoginDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
        
    }
    
    public class RegisterDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }
    }
}