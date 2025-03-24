using MoviesLibrary.Domain.Entities;

namespace MoviesLibrary.Application.Repositories;

public interface IMovieRepository
{
    Task<List<Movie>> GetMovies(int? startYear, int? endYear, string[]? genres, string? title, int page, CancellationToken cancellationToken = default);
    Task<Movie?> GetMovieById(int id, CancellationToken cancellationToken = default);

    void AddMovie(Movie movie);
    void UpdateMovie(Movie movie);
    void DeleteMovie(Movie movie);
}