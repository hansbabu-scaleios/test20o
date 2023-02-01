using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AI.Finder.BE.Service.Features.Gender;
    public class GenderModelConfiguration: IEntityTypeConfiguration<GenderModel>{
        public void Configure(EntityTypeBuilder<GenderModel> builder) {
            builder.ToTable("gender");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();
            builder.HasIndex(e => e.Name)
            .IsUnique();
            builder.Property(e=>e.Name)
            .HasMaxLength(20);
        }}
