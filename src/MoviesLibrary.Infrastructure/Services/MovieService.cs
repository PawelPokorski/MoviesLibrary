using MoviesLibrary.Application.Repositories;
using MoviesLibrary.Application.Services;
using MoviesLibrary.Application;
using MoviesLibrary.Domain.Entities;
using MoviesLibrary.Domain;
using MoviesLibrary.Application.Dtos;

namespace MoviesLibrary.Infrastructure.Services;

public class MovieService(IMovieRepository movieRepository, IUnitOfWork unitOfWork) : IMovieService
{
    public async Task<List<Movie>> GetMovies(int? startYear, int? endYear, string[]? genres, string? title, int page)
    {
        var movies = await movieRepository.GetMovies(startYear, endYear, genres, title, page);

        return movies;
    }

    public async Task<Movie?> GetMovieById(int id)
    {
        var movie = await movieRepository.GetMovieById(id);

        return movie;
    }

    public async Task<Result> AddMovie(MovieDto movieDto)
    {
        var movie = new Movie
        {
            Title = movieDto.Title,
            Description = movieDto.Description,
            Rating = movieDto.Rating,
            Genre = movieDto.Genre,
            ReleaseYear = movieDto.ReleaseYear
        };

        try
        {
            movieRepository.AddMovie(movie);
            await unitOfWork.CommitChangesAsync();
            return Result.Success();
        }
        catch
        {
            return Result.Failure("Wystąpił problem przy dodawaniu filmu.");
        }
    }

    public async Task<Result> UpdateMovie(int id, MovieDto movieDto)
    {
        var movie = await GetMovieById(id);

        if (movie == null)
            return Result.Failure("Nie znaleziono filmu");

        movie.Title = movieDto.Title;
        movie.Description = movieDto.Description;
        movie.Rating = movieDto.Rating;
        movie.Genre = movieDto.Genre;
        movie.ReleaseYear = movieDto.ReleaseYear;

        try
        {
            movieRepository.UpdateMovie(movie);
            await unitOfWork.CommitChangesAsync();
            return Result.Success();
        }
        catch
        {
            return Result.Failure("Wystąpił problem przy aktualizowaniu filmu.");
        }
    }

    public async Task<Result> DeleteMovie(int id)
    {
        var movie = await GetMovieById(id);

        if (movie == null)
            return Result.Failure("Nie znaleziono filmu");

        try
        {
            movieRepository.DeleteMovie(movie);
            await unitOfWork.CommitChangesAsync();
            return Result.Success();
        }
        catch
        {
            return Result.Failure("Wystąpił problem przy usuwaniu filmu.");
        }
    }
}
