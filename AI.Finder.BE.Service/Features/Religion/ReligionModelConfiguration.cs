using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AI.Finder.BE.Service.Features.Religion;
    public class ReligionModelConfiguration:IEntityTypeConfiguration<ReligionModel>{
          public void Configure(EntityTypeBuilder<ReligionModel>builder){
            builder.ToTable("religion");
            builder.HasKey(e=>e.Id);
            builder.Property(e=>e.Id).ValueGeneratedOnAdd();
            builder.HasIndex(e=>e.Name) .IsUnique();
            builder.Property(e=>e.Name).HasMaxLength(250);
            builder.Property(e=>e.TreePath).HasColumnType("ltree");
            builder.Property(e=>e.Type).HasMaxLength(50);
            builder.Property(e=>e.Id).HasColumnName("id");
            builder.Property(e=>e.ParentId).HasColumnName("parentid");
            builder.Property(e=>e.TreePath).HasColumnName("treepath");
            builder.Property(e=>e.Name).HasColumnName("name");
            builder.Property(e=>e.Type).HasColumnName("type");
         }}
