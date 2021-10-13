using CleanArchitectureTemplate.Domain;
using CleanArchitectureTemplate.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Persistence
{
    public class CleanArchitectureTemplateDbContext : AuditableDbContext
    {
        public CleanArchitectureTemplateDbContext(DbContextOptions<CleanArchitectureTemplateDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CleanArchitectureTemplateDbContext).Assembly);
        }
    }
}
