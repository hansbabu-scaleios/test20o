using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AI.Finder.BE.Service.Features.ActivityLog
{
    public class ActivityLogModelConfiguration : IEntityTypeConfiguration<ActivityLogModel>
    {
        public void Configure(EntityTypeBuilder<ActivityLogModel> builder)
        {
            builder.ToTable("activity_log");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.TimeStamp).HasColumnType("timestamp without time zone");
        }
    }
}