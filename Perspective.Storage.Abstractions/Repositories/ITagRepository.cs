using Perspective.Storage.Abstractions.QueryBuilders;
using Perspective.Storage.Models;

namespace Perspective.Storage.Abstractions.Repositories
{
    public interface ITagRepository : IRepository<Tag>
    {
        public ITagsSelectQueryBuilder GetSelectQueryBuilder();
    }
}
