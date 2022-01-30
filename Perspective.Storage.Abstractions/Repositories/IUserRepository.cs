using Perspective.Storage.Abstractions.QueryBuilders;
using Perspective.Storage.Models;
using System.Threading.Tasks;

namespace Perspective.Storage.Abstractions.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<User> FindAsync(string email);
        public Task<bool> IsExistAsync(string email);
        public IUsersSelectQueryBuilder GetSelectQueryBuilder();
    }
}
