using MoviesLibrary.Application.Dtos;
using MoviesLibrary.Domain.Entities;

namespace MoviesLibrary.Application.Services;

public interface IMovieService
{
    Task<List<Movie>> GetMovies(int? startYear, int? endYear, string[]? genres, string? title, int page = 1);
    Task<Movie?> GetMovieById(int id);

    Task<Result> AddMovie(MovieDto movieDto);
    Task<Result> UpdateMovie(int id, MovieDto movieDto);
    Task<Result> DeleteMovie(int id);
}