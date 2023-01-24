using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace AI.Finder.BE.Service
{
    public class FinderDbContext : DbContext
    {
          public FinderDbContext(DbContextOptions<FinderDbContext> options)
      : base(options) { }
       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("ltree");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}