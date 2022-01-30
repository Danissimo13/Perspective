using Perspective.Storage.Abstractions.QueryBuilders;
using Perspective.Storage.Models;

namespace Perspective.Storage.Abstractions.Repositories
{
    public interface IObjectiveRepository : IRepository<Objective>
    {
        public IObjectivesSelectQueryBuilder GetSelectQueryBuilder(long ownerId);
    }
}
