using Perspective.Storage.Abstractions.Enums;
using Perspective.Storage.Models;
using Perspective.Storage.MSSQL.QueryBuilders;
using System.Collections.Generic;

namespace Perspective.Storage.Abstractions.QueryBuilders
{
    public interface IObjectivesSelectQueryBuilder : ISelectQueryBuilder<Objective>
    {
        public IObjectivesSelectQueryBuilder Keywords(string keywords);
        public IObjectivesSelectQueryBuilder Sort(ObjectivesSortType sortType);
        public IObjectivesSelectQueryBuilder MinCost(decimal min);
        public IObjectivesSelectQueryBuilder MaxCost(decimal max);
        public IObjectivesSelectQueryBuilder MinProgress(decimal min);
        public IObjectivesSelectQueryBuilder MaxProgress(decimal max);
        public IObjectivesSelectQueryBuilder WithTags(IEnumerable<long> tagsId);
    }
}
