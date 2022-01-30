using System;
using System.Collections.Generic;

namespace Perspective.Storage.MSSQL.QueryBuilders
{
    public interface ISelectQueryBuilder<T>
    {
        public ISelectQueryBuilder<T> ForRead();
        public ISelectQueryBuilder<T> Skip(int count);
        public ISelectQueryBuilder<T> Take(int count);
        public IEnumerable<T> Select(Func<T, T> selector);
    }
}
