using System.Reflection;
using AI.Finder.BE.Service.Features.Samples;
using AI.Finder.BE.Service.Features.Samples.SampleAutherization;
using AI.Finder.BE.Service.Features.User;
using Microsoft.EntityFrameworkCore;
using AI.Finder.BE.Service.Features.Candidate;
using AI.Finder.BE.Service.Features.Religion;
using AI.Finder.BE.Service.Features.ActivityType;
using AI.Finder.BE.Service.Features.ActivityLog;
// TODO: All the namespace become like below
namespace AI.Finder.BE.Service;
// TODO: All the class and functions brackets in same line
public class FinderDbContext : DbContext{
    public FinderDbContext(DbContextOptions options): base(options) { }
// TODO: Add sample implimentation
  public DbSet<SampleModel> Sample{ get; set; }
  public DbSet<SampleAutherizationModel> SampleAutherization{ get; set; }

  public DbSet<UserModel> Users { get; set; }
  public DbSet<CandidateModel> Candidates { get; set; }

  public DbSet<ReligionModel> Religions{get;set;}
  public DbSet<ActivityTypeModel> ActivityTypes{ get; set; }
  public DbSet<ActivityLogModel> ActivityLogs{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)=> _ = modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinderDbContext).Assembly);
}
