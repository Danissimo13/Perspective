using Perspective.Storage.Abstractions;
using Perspective.Storage.Abstractions.Repositories;
using Perspective.Storage.Models;
using Perspective.Storage.MSSQL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Perspective.Storage.MSSQL.Tests
{
    public class StorageTest
    {
        [Fact]
        public void CreateCustomRepositoryTest()
        {
            //Arrange
            var storage = StorageFactory.CreateTestStorage();

            //Act
            var customRepository = storage.CreateRepository<IUserRepository>();

            //Assert
            Assert.True(customRepository is UserRepository);
        }

        [Fact]
        public void AddAndFindUserTest()
        {
            //Arrange
            var storage = StorageFactory.CreateTestStorage();
            var userRepository = storage.CreateRepository<IUserRepository>();

            //Act
            var user = new User() { Email = "test@gmail.com" };
            userRepository.AddAsync(user).Wait(); storage.Save();

            //Assert
            Assert.NotNull(FindAndDeleteUser(storage, user.Email));
        }

        [Fact]
        public async Task DeleteUserTest()
        {
            //Arrange
            var storage = StorageFactory.CreateTestStorage();
            var userRepository = storage.CreateRepository<IUserRepository>();

            //Act
            var user = new User() { Email = "test@gmail.com" };
            await userRepository.AddAsync(user); storage.Save();
            userRepository.Delete(user); storage.Save();

            //Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () => await userRepository.FindAsync(user.Email));
        }

        private static User FindAndDeleteUser(IStorage storage, string email)
        {
            var repository = storage.CreateRepository<IUserRepository>();
            var user = repository.FindAsync(email).Result;
            repository.Delete(user);
            storage.Save();

            return user;
        }
    }
}