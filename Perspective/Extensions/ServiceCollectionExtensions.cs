using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Perspective.Managers;
using Perspective.Managers.Implementations;
using Perspective.Storage.Abstractions;
using Perspective.Storage.Models;

namespace Perspective.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMSSqlStorage(this IServiceCollection services, string connectionStr)
        {
            services.AddScoped<IStorage, Storage.MSSQL.Storage>(provider => new Storage.MSSQL.Storage(connectionStr));
            return services;
        }

        public static IServiceCollection AddUserManager(this IServiceCollection services)
        {
            services.AddScoped<IUserManager, UserManager>();
            return services;
        }

        public static IServiceCollection AddPasswordHasher(this IServiceCollection services)
        {
            services.AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();
            return services;
        }
    }
}
