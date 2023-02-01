using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AI.Finder.BE.Service.Features.Candidate;
    public class CandidateModelConfiguration:IEntityTypeConfiguration<CandidateModel>{
        public void Configure(EntityTypeBuilder<CandidateModel>builder){
            builder.ToTable("candidate");
            builder.HasKey(e=>e.Id);
            builder.HasOne(e=>e.CreatedContact);
            builder.Property(e=>e.Id)
            .ValueGeneratedOnAdd();
            builder.Property(e=>e.DOB)
             .HasColumnType("timestamp without time zone");
             builder.Property(e=>e.Name)
            .HasMaxLength(50);
              builder.Property(e=>e.OtherReligion)
            .HasMaxLength(250);
              builder.Property(e=>e.OtherReligiousInformation)
            .HasMaxLength(250);
              builder.Property(e=>e.AboutMe)
            .HasMaxLength(1000);
              builder.Property(e => e.ResidentTown)
            .HasMaxLength(150);
              builder.Property(e => e.NativeTown)
            .HasMaxLength(150);
              builder.Property(e => e.CandidateAssetDetails)
            .HasMaxLength(500);
              builder.Property(e => e.RegistrationId)
            .HasMaxLength(10);
         }
    }

