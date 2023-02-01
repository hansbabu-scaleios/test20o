using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AI.Finder.BE.Service.Features.MaritalStatus;
    public class MaritalStatusModelConfiguration:IEntityTypeConfiguration<MaritalStatusModel>{
         public void Configure(EntityTypeBuilder<MaritalStatusModel>builder){
            builder.ToTable("marital_status");
            builder.HasKey(e=>e.Id);
            builder.Property(e=>e.Id)
            .ValueGeneratedOnAdd();
            builder.HasIndex(e=>e.Name)
            .IsUnique();
             builder.Property(e=>e.Name)
            .HasMaxLength(50);
         }
    }
