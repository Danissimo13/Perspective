using Microsoft.EntityFrameworkCore;
using Perspective.Storage.Models;

namespace Perspective.Storage.MSSQL
{
    internal sealed class StorageContext : DbContext
    {
        public StorageContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(u => u.Id);

                e.HasAlternateKey(u => u.Email);

                e.HasMany(u => u.Objectives)
                 .WithOne(o => o.Owner)
                 .HasForeignKey(o => o.OwnerId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Objective>(e => 
            {
                e.HasKey(o => o.Id);

                e.HasAlternateKey(o => o.Number);

                e.Property(o => o.Cost).HasColumnType("MONEY");
                e.Property(o => o.Progress).HasColumnType("DECIMAL(3,2)");

                e.HasMany(o => o.Tags)
                 .WithMany(t => t.Objectives);
            });

            modelBuilder.Entity<Tag>(e =>
            {
                e.HasKey(t => t.Id);

                e.HasAlternateKey(t => t.Name);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
