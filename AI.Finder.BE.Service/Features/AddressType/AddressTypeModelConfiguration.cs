using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AI.Finder.BE.Service.Features.AddressType;
    public class AddressTypeModelConfiguration:IEntityTypeConfiguration<AddressTypeModel>{
         public void Configure(EntityTypeBuilder<AddressTypeModel> builder){
            builder.ToTable("address_type");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();
            builder.Property(e=>e.Name)
            .HasMaxLength(50);
        }
    }
