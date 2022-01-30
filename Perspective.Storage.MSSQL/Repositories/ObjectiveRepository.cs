using Microsoft.EntityFrameworkCore;
using Perspective.Storage.Abstractions.QueryBuilders;
using Perspective.Storage.Abstractions.Repositories;
using Perspective.Storage.Models;
using Perspective.Storage.MSSQL.QueryBuilders;
using System.Linq;

namespace Perspective.Storage.MSSQL.Repositories
{
    public class ObjectiveRepository : Repository<Objective>, IObjectiveRepository
    {
        internal ObjectiveRepository(StorageContext dbContext) : base(dbContext) { }

        public IObjectivesSelectQueryBuilder GetSelectQueryBuilder(long ownerId)
        {
            var objectives = _dbContext.Set<Objective>()
                                       .Include(o => o.Tags)
                                       .AsQueryable();

            objectives = objectives.Where(o => o.OwnerId == ownerId);
            
            return new ObjectivesSelectQueryBuilder(objectives);
        }
    }
}
