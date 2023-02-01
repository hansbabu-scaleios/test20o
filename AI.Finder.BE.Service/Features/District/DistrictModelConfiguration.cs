using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AI.Finder.BE.Service.Features.District;
    public class DistrictModelConfiguration:IEntityTypeConfiguration<DistrictModel>{
        public void Configure(EntityTypeBuilder<DistrictModel>builder){
            builder.ToTable("district");
            builder.HasKey(e=>e.Id);
            builder.Property(e=>e.Id)
            .ValueGeneratedOnAdd();
             builder.Property(e=>e.Name)
            .HasMaxLength(250);
         }
    }
