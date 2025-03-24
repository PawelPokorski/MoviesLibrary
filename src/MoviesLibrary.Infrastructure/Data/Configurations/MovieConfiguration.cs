using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesLibrary.Domain.Entities;

namespace MoviesLibrary.Infrastructure.Data.Configurations;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public virtual void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies");

        builder.HasKey(k => k.Id);

        builder.Property(m => m.Title)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(m => m.Rating)
            .HasColumnType("decimal(2,1)");

        builder.ToTable(t =>
        {
            t.HasCheckConstraint("CK_Year_Range", "[ReleaseYear] >= 1801 AND [ReleaseYear] <= 2155 OR [ReleaseYear] = 0000");
        });
    }
}