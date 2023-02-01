using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AI.Finder.BE.Service.Features.BodyType;

    public class BodyTypeModelConfiguration:IEntityTypeConfiguration<BodyTypeModel>{
         public void Configure(EntityTypeBuilder<BodyTypeModel>builder){
            builder.ToTable("body_type");
            builder.HasKey(e=>e.Id);
            builder.Property(e=>e.Id)
            .ValueGeneratedOnAdd();
            builder.HasIndex(e=>e.Name)
            .IsUnique();
             builder.Property(e=>e.Name)
            .HasMaxLength(50);
         }}