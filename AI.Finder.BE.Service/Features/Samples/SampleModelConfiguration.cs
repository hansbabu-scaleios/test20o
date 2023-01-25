using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AI.Finder.BE.Service.Features.Samples;

    public class SampleModelConfiguration : IEntityTypeConfiguration<SampleModel> {
    public void Configure(EntityTypeBuilder<SampleModel> builder) {

        builder.ToTable("sample");
        builder.HasKey(m => m.Id);
        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();
        builder.HasIndex(m => m.Code).IsUnique();
        builder.Property(m => m.AuditProp).HasColumnType("jsonb");
       //TODO:Ltree implimentation
    }

}