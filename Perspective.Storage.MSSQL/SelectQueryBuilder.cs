using Microsoft.EntityFrameworkCore;
using Perspective.Storage.MSSQL.QueryBuilders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Perspective.Storage.MSSQL
{
    public abstract class SelectQueryBuilder<T> : ISelectQueryBuilder<T> where T : class
    {
        protected IQueryable<T> _set;

        internal SelectQueryBuilder(IQueryable<T> set)
        {
            _set = set;
        }

        public ISelectQueryBuilder<T> ForRead()
        {
            _set = _set.AsNoTracking();
            return this;
        }

        public ISelectQueryBuilder<T> Skip(int count)
        {
            _set = _set.Skip(count);
            return this;
        }

        public ISelectQueryBuilder<T> Take(int count)
        {
            _set = _set.Take(count);
            return this;
        }

        public IEnumerable<T> Select(Func<T, T> selector)
        {
            return _set.Select(selector);
        }
    }
}
