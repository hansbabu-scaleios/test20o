using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AI.Finder.BE.Service.Features.ActivityType;
    public class ActivityTypeModelConfiguration : IEntityTypeConfiguration<ActivityTypeModel>{
        public void Configure(EntityTypeBuilder<ActivityTypeModel> builder){
            builder.ToTable("activity");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Code).HasMaxLength(20);
            builder.HasIndex(e => e.Code).IsUnique();
            builder.Property(e => e.Type).HasMaxLength(50);
        }
    }