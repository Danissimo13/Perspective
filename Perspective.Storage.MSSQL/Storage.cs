using Microsoft.EntityFrameworkCore;
using Perspective.Storage.Abstractions;
using System;
using System.Linq;
using System.Reflection;

namespace Perspective.Storage.MSSQL
{
    public sealed class Storage : IStorage, IDisposable
    {
        private readonly StorageContext _dbContext;

        public Storage(string connectionStr)
        {
            var dbOptionsBuilder = new DbContextOptionsBuilder().UseSqlServer(connectionStr);

            _dbContext = new StorageContext(dbOptionsBuilder.Options);
        }

        public IRepository<T> CreateDefaultRepository<T>() where T : class
        {
            IRepository<T> repository = new Repository<T>(_dbContext);

            return repository;
        }

        public T CreateRepository<T>() where T : class
        {
            T repository = default;
            foreach (var type in GetType().Assembly.GetTypes())
            {
                if (type.IsAssignableTo(typeof(T)))
                {
                    //Activator.CreateInstance() doesnt work with non-public constructors
                    var constructor = type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
                    repository = (T)constructor.First().Invoke(new[] { _dbContext });
                }
            }

            return repository;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}