using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AI.Finder.BE.Service.Features.Country;
    public class CountryModelConfiguration:IEntityTypeConfiguration<CountryModel>{
    public void Configure(EntityTypeBuilder<CountryModel>builder){
            builder.ToTable("country");
            builder.HasKey(e=>e.Id);
            builder.Property(e=>e.Id)
            .ValueGeneratedOnAdd();
            builder.HasIndex(e=>e.Name)
            .IsUnique();
            builder.Property(e=>e.Name)
            .HasMaxLength(250);
         }
    }
