using Perspective.Storage.Abstractions.QueryBuilders;
using Perspective.Storage.Abstractions.Repositories;
using Perspective.Storage.Models;
using Perspective.Storage.MSSQL.QueryBuilders;

namespace Perspective.Storage.MSSQL.Repositories
{
    class TagRepository : Repository<Tag>, ITagRepository
    {
        internal TagRepository(StorageContext dbContext) : base(dbContext) { }

        public ITagsSelectQueryBuilder GetSelectQueryBuilder()
        {
            var tags = _dbContext.Set<Tag>().AsQueryable();

            return new TagsSelectQueryBuilder(tags);
        }
    }
}
