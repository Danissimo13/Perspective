using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Perspective.Storage.MSSQL.Migrations
{
    internal class MigrationDatabaseFactory : IDesignTimeDbContextFactory<StorageContext>
    {
        public StorageContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            string connectionStr;
            #if DEBUG
                connectionStr = config.GetConnectionString("DevelopmentDB");
            #else
                connectionStr = config.GetConnectionString("ProductionDB");
            #endif
            
            var optionsBuilder = new DbContextOptionsBuilder<StorageContext>();
            var options = optionsBuilder.UseSqlServer(connectionStr).Options;

            return new StorageContext(options);
        }
    }
}
