using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AI.Finder.BE.Service.Features.State;
    public class StateModelConfiguration:IEntityTypeConfiguration<StateModel>{
    public void Configure(EntityTypeBuilder<StateModel>builder){
            builder.ToTable("state");
            builder.HasKey(e=>e.Id);
            builder.Property(e=>e.Id)
            .ValueGeneratedOnAdd();
            builder.HasIndex(e=>e.Name)
            .IsUnique();
         }
    }