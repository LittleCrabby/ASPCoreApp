using Microsoft.EntityFrameworkCore;
using System.Linq;
using ASPCoreApp.Core.Entities;
using ASPCoreApp.Core.SharedKernel;
using System;

namespace ASPCoreApp.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        public override int SaveChanges()
        {
            AddTimestamps();

            return base.SaveChanges();
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).DateCreated = DateTime.UtcNow;
                }
            }
        }
    }
}