using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Perspective.Storage.Abstractions;
using Perspective.Storage.Abstractions.Repositories;
using Perspective.Storage.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Perspective.Managers.Implementations
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _repository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IConfiguration _configuration;

        public UserManager(IStorage storage, IPasswordHasher<User> passwordHasher, IConfiguration configuration)
        {
            _repository = storage.CreateRepository<IUserRepository>();
            _passwordHasher = passwordHasher;
            _configuration = configuration;
        }

        public bool CheckPassword(User user, string password)
        {
            var result = ((int)_passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password)) == 1;

            return result;
        }

        public async Task<User> FindAsync(string email)
        {
            return await _repository.FindAsync(email);
        }

        public async Task SignInAsync(HttpContext httpContext, User user)
        {
            Claim[] claims = new Claim[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName)
            };

            var identity = new ClaimsIdentity(claims, nameof(Perspective), ClaimTypes.Name, ClaimTypes.Role);
            var principal = new ClaimsPrincipal(identity);

            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }

        public async Task<bool> TryRegistrationAsync(User user, string password)
        {
            bool isExist = await _repository.IsExistAsync(user.Email);
            if(isExist) return false;

            user.PasswordHash = _passwordHasher.HashPassword(user, password);

            await _repository.AddAsync(user);
            await _repository.SaveAsync();

            return true;
        }
    }
}
