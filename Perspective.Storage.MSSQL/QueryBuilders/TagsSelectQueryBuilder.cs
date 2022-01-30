using Perspective.Storage.Abstractions.QueryBuilders;
using Perspective.Storage.Models;
using System.Linq;

namespace Perspective.Storage.MSSQL.QueryBuilders
{
    public class TagsSelectQueryBuilder : SelectQueryBuilder<Tag>, ITagsSelectQueryBuilder
    {
        internal TagsSelectQueryBuilder(IQueryable<Tag> set) : base(set) { }
    }
}
