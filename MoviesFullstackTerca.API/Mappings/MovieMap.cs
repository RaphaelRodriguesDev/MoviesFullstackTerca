using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesFullstackTerca.API.Models;

namespace MoviesFullstackTerca.API.Mappings;

public class MovieMap : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("movies");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Title)
            .IsRequired() //não pode ser nulo.
            .HasColumnType("VARCHAR")
            .HasColumnName("title")
            .HasMaxLength(100);

        builder.Property(x => x.PosterUrl)
            .IsRequired() //não pode ser nulo.
            .HasColumnType("VARCHAR")
            .HasColumnName("poster_url")
            .HasMaxLength(255);

        builder.Property(x => x.Overview)
            .IsRequired()
            .HasColumnType("TEXT")
            .HasColumnName("overview");
    }
}
