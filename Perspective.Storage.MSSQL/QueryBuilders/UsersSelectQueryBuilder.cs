using Perspective.Storage.Abstractions.QueryBuilders;
using Perspective.Storage.Models;
using System.Linq;

namespace Perspective.Storage.MSSQL.QueryBuilders
{
    public class UsersSelectQueryBuilder : SelectQueryBuilder<User>, IUsersSelectQueryBuilder
    {
        internal UsersSelectQueryBuilder(IQueryable<User> set) : base(set) { }
    }
}
