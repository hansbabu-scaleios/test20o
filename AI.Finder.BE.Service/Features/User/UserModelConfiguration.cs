using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AI.Finder.BE.Service.Features.User;
    public class UserModelConfiguration: IEntityTypeConfiguration<UserModel> {
    public void Configure(EntityTypeBuilder<UserModel> builder) {

        builder.ToTable("User");
        builder.HasKey(m => m.UserId);
        builder.Property(e => e.UserId)
            .ValueGeneratedOnAdd();
    }

}