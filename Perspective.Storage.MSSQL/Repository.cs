using Perspective.Storage.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Perspective.Storage.MSSQL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private protected readonly StorageContext _dbContext;

        internal Repository(StorageContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async virtual Task<T> FindAsync(object key)
        {
            var set = _dbContext.Set<T>();

            var entity = await set.FindAsync(key);
            if (entity == null) throw new KeyNotFoundException(nameof(key));

            return entity;
        }

        public async virtual Task<bool> IsExistAsync(object key)
        {
            var set = _dbContext.Set<T>();

            var entity = await set.FindAsync(key);
            
            return (entity != null);
        }

        public async virtual Task AddAsync(T entity)
        {
            var set = _dbContext.Set<T>();

            await set.AddAsync(entity);
        }

        public virtual void Delete(T entity)
        {
            var set = _dbContext.Set<T>();

            set.Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            var set = _dbContext.Set<T>();

            set.Update(entity);
        }

        

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
