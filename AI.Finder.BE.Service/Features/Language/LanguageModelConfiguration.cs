using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AI.Finder.BE.Service.Features.Language;
    public class LanguageModelConfiguration:IEntityTypeConfiguration<LanguageModel>{
        public void Configure(EntityTypeBuilder<LanguageModel>builder){
            builder.ToTable("language");
            builder.HasKey(e=>e.Id);
            builder.Property(e=>e.Id)
            .ValueGeneratedOnAdd();
            builder.HasIndex(e=>e.Name)
            .IsUnique();
             builder.Property(e=>e.Name)
            .HasMaxLength(50);
         }
    }

