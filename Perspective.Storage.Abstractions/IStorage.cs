namespace Perspective.Storage.Abstractions
{
    public interface IStorage
    {
        public IRepository<T> CreateDefaultRepository<T>() where T : class;
        public T CreateRepository<T>() where T : class;
        public void Save();
    }
}
