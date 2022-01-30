using Perspective.Storage.Models;
using System.Collections.Generic;
using System.Linq;
using Perspective.Storage.Abstractions.Enums;
using Perspective.Storage.Abstractions.QueryBuilders;

namespace Perspective.Storage.MSSQL.QueryBuilders
{
    public class ObjectivesSelectQueryBuilder : SelectQueryBuilder<Objective>, IObjectivesSelectQueryBuilder
    {
        internal ObjectivesSelectQueryBuilder(IQueryable<Objective> set) : base(set) { }

        public IObjectivesSelectQueryBuilder Keywords(string keywords)
        {
            _set = _set.Where(o => o.Name.Contains(keywords) || o.Description.Contains(keywords));
            return this;
        }

        public IObjectivesSelectQueryBuilder Sort(ObjectivesSortType sortType)
        {
            _set = sortType switch
            {
                ObjectivesSortType.AscByNumber => _set.OrderBy(o => o.Number),
                ObjectivesSortType.DescByNumber => _set.OrderByDescending(o => o.Number),
                ObjectivesSortType.AscByCost => _set.OrderBy(o => o.Cost),
                ObjectivesSortType.DescByCost => _set.OrderByDescending(o => o.Cost),
                ObjectivesSortType.AscByProgress => _set.OrderBy(o => o.Progress),
                ObjectivesSortType.DescByProgress => _set.OrderByDescending(o => o.Progress),
                _ => _set.OrderBy(o => o.Number)
            };

            return this;
        }

        public IObjectivesSelectQueryBuilder MinCost(decimal min)
        {
            _set = _set.Where(o => o.Cost >= min);
            return this;
        }

        public IObjectivesSelectQueryBuilder MaxCost(decimal max)
        {
            _set = _set.Where(o => o.Cost <= max);
            return this;
        }

        public IObjectivesSelectQueryBuilder MinProgress(decimal min)
        {
            _set = _set.Where(o => o.Progress >= min);
            return this;
        }

        public IObjectivesSelectQueryBuilder MaxProgress(decimal max)
        {
            _set = _set.Where(o => o.Progress <= max);
            return this;
        }

        public IObjectivesSelectQueryBuilder WithTags(IEnumerable<long> tagsId)
        {
            _set = _set.Where(o => o.Tags.Select(t => t.Id).Intersect(tagsId).Any());
            return this;
        }
    }
}
