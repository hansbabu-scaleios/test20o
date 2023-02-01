using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AI.Finder.BE.Service.Features.Resident;
public class ResidentTypeModelConfiguration:IEntityTypeConfiguration<ResidentTypeModel>{
        public void Configure(EntityTypeBuilder<ResidentTypeModel>builder){
            builder.ToTable("resident_type");
            builder.HasKey(e=>e.Id);
            builder.Property(e=>e.Id)
            .ValueGeneratedOnAdd();
            builder.HasIndex(e=>e.Name)
            .IsUnique();
             builder.Property(e=>e.Name)
            .HasMaxLength(50);
         }}