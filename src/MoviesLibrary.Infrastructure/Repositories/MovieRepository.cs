using Microsoft.EntityFrameworkCore;
using MoviesLibrary.Application.Repositories;
using MoviesLibrary.Domain.Entities;
using MoviesLibrary.Infrastructure.Data;

namespace MoviesLibrary.Infrastructure.Repositories;

public class MovieRepository(ApplicationDbContext context) : IMovieRepository
{
    public async Task<List<Movie>> GetMovies(int? startYear, int? endYear, string[]? genres, string? title, int page, CancellationToken cancellationToken)
    {
        var query = context.Movies.AsQueryable();

        if(startYear.HasValue)
            query = query.Where(m => m.ReleaseYear >= startYear.Value);

        if(endYear.HasValue)
            query = query.Where(m => m.ReleaseYear <= endYear.Value);

        if(genres is { Length: > 0})
            query = query.Where(m => genres.Any(g => m.Genre != null && m.Genre.Contains(g)));

        if(!string.IsNullOrEmpty(title))
            query = query.Where(m => m.Title != null && m.Title.Contains(title));

        return await query
            .Skip((page - 1) * 10)
            .Take(10)
            .ToListAsync(cancellationToken);
    }

    public async Task<Movie?> GetMovieById(int id, CancellationToken cancellationToken)
    {
        return await context.Movies.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public void AddMovie(Movie movie)
    {
        context.Movies.Add(movie);
    }

    public void UpdateMovie(Movie movie)
    {
        context.Movies.Update(movie);
    }

    public void DeleteMovie(Movie movie)
    {
        context.Movies.Remove(movie);
    }
}