using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AI.Finder.BE.Service.Features.Town;
    public class TownModelConfiguration: IEntityTypeConfiguration<TownModel>{
        public void Configure(EntityTypeBuilder<TownModel> builder){
            builder.ToTable("town");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.HasIndex(e => e.Name).IsUnique();
            builder.Property(e => e.Name).HasMaxLength(250);
        }
}