using System.Threading.Tasks;

namespace Perspective.Storage.Abstractions
{
    public interface IRepository<T> where T : class
    {
        public Task<T> FindAsync(object key);
        public Task<bool> IsExistAsync(object key);
        public Task AddAsync(T entity);
        public void Edit(T entity);
        public void Delete(T entity);
        public Task SaveAsync();
    }
}
