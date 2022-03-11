using Domain.Entities;
using Domain.Entities.Interfaces;
using Domain.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data
{
    public class ApplicationDbContext : DbContext
    { 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<BookEntity> Books { get;set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
                {
                    entityType.AddSoftDeleteQueryFilter();
                }
            }
        }
    }
}
