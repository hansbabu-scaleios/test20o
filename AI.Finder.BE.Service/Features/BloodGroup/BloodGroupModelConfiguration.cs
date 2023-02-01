using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AI.Finder.BE.Service.Features.BloodGroup;
    public class BloodGroupModelConfiguration: IEntityTypeConfiguration<BloodGroupModel>{
        public void Configure(EntityTypeBuilder<BloodGroupModel> builder){
            builder.ToTable("blood_group");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();
            builder.HasIndex(e => e.Name)
            .IsUnique();
            builder.Property(e=>e.Name)
            .HasMaxLength(5);
        }
    }