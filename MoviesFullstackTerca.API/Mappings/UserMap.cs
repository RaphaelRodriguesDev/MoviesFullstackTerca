using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesFullstackTerca.API.Models;

namespace MoviesFullstackTerca.API.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Username)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasColumnName("username")
            .HasMaxLength(50);

        builder.Property(x => x.Password)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasMaxLength(100)
            .HasColumnName("password");
    }
}
