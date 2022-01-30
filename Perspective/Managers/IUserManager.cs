using Microsoft.AspNetCore.Http;
using Perspective.Storage.Models;
using System.Threading.Tasks;

namespace Perspective.Managers
{
    public interface IUserManager
    {
        public Task<User> FindAsync(string email);
        public bool CheckPassword(User user, string password);
        public Task SignInAsync(HttpContext httpContext, User user);
        public Task<bool> TryRegistrationAsync(User user, string password);
    }
}
