using System.Reflection;
using AI.Finder.BE.Service.Features.Samples;
using AI.Finder.BE.Service.Features.User;
using Microsoft.EntityFrameworkCore;
// TODO: All the namespace become like below
namespace AI.Finder.BE.Service;
// TODO: All the class and functions brackets in same line
public class FinderDbContext : DbContext{
    public FinderDbContext(DbContextOptions options): base(options) { }
// TODO: Add sample implimentation
  public DbSet<SampleModel> Sample{ get; set; }
   public DbSet<UserModel> User{ get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)=> _ = modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinderDbContext).Assembly);
}
