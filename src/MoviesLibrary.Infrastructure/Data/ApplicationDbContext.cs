using MoviesLibrary.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using MoviesLibrary.Domain.Entities;

namespace MoviesLibrary.Infrastructure.Data;

public class ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
    public DbSet<Movie> Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new MovieConfiguration());
    }
}