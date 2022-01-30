using Microsoft.EntityFrameworkCore;
using Perspective.Storage.Abstractions.QueryBuilders;
using Perspective.Storage.Abstractions.Repositories;
using Perspective.Storage.Models;
using Perspective.Storage.MSSQL.QueryBuilders;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Perspective.Storage.MSSQL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        internal UserRepository(StorageContext dbContext) : base(dbContext) { }

        public async Task<User> FindAsync(string email)
        {
            var set = _dbContext.Set<User>();

            var user = await set.FirstOrDefaultAsync(u => u.Email == email);
            if(user == null) throw new KeyNotFoundException(nameof(email));

            return user;
        }

        public async Task<bool> IsExistAsync(string email)
        {
            var set = _dbContext.Set<User>();

            var user = await set.FirstOrDefaultAsync(u => u.Email == email);
            
            return (user != null);
        }

        public IUsersSelectQueryBuilder GetSelectQueryBuilder()
        {
            var users = _dbContext.Set<User>().AsQueryable();

            return new UsersSelectQueryBuilder(users);
        }
    }
}
