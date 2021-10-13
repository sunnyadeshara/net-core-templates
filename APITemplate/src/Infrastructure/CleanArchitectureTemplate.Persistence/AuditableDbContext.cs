using CleanArchitectureTemplate.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Persistence
{
    public abstract class AuditableDbContext : DbContext
    {
        public AuditableDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual async Task<int> SaveChangesAsync(string username = "SYSTEM")
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified))
            {
                entry.Entity.LastModified = DateTime.Now;
                entry.Entity.LastModifiedBy = username;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                    entry.Entity.CreatedBy = username;
                }
            }

            var result = await base.SaveChangesAsync();

            return result;
        }
    }
}