using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AI.Finder.BE.Service.Features.User;

public class UserModelConfiguration : IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        builder.ToTable("user");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(m => m.UserId).ValueGeneratedOnAdd();
        builder.HasIndex(m => m.UserId).IsUnique();
        builder.HasIndex(e => e.EmailId).IsUnique();
        builder.HasIndex(e => e.PhoneNumber).IsUnique();
        builder.Property(e => e.EmailTokenGeneratedTimestamp)
            .HasColumnType("timestamp without time zone");
        builder.Property(e => e.PhoneTokenGeneratedTimestamp)
            .HasColumnType("timestamp without time zone");
        //TODO: CandidateId & RelationId to be added after creation of candidate and addresstype models
    }
}