using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AI.Finder.BE.Service.Features.Complexion;

    public class ComplexionModelConfiguration:IEntityTypeConfiguration<ComplexionModel>{
        public void Configure(EntityTypeBuilder<ComplexionModel>builder){
            builder.ToTable("complexion");
            builder.HasKey(e=>e.Id);
            builder.Property(e=>e.Id)
            .ValueGeneratedOnAdd();
            builder.HasIndex(e=>e.Name)
            .IsUnique();
             builder.Property(e=>e.Name)
            .HasMaxLength(50);
         }
    }
