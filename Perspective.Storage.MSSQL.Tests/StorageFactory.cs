using Perspective.Storage.Abstractions;

namespace Perspective.Storage.MSSQL.Tests
{
    internal static class StorageFactory
    {
        public static IStorage CreateTestStorage()
        {
            return new Storage("Server=localhost\\SQLEXPRESS;Database=PerspectiveTest;Trusted_Connection=True");
        }
    }
}
