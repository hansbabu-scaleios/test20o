using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AI.Finder.BE.Service.Features.Unit;
    public class UnitModelConfiguration:IEntityTypeConfiguration<UnitModel>{
         public void Configure(EntityTypeBuilder<UnitModel>builder){
            builder.ToTable("unit");
            builder.HasKey(e=>e.Id);
            builder.Property(e=>e.Id)
            .ValueGeneratedOnAdd();
            builder.Property(e=>e.BaseValue)
            .HasColumnType("real");
            builder.HasIndex(e=>e.Name)
            .IsUnique();
            builder.Property(e=>e.Name)
            .HasMaxLength(50);
            builder.HasIndex(e=>e.Code)
            .IsUnique();

         }}
