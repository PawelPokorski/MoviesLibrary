using MoviesLibrary.Application.Repositories;
using MoviesLibrary.Application.Services;
using MoviesLibrary.Infrastructure.Data;
using MoviesLibrary.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoviesLibrary.Domain;
using MoviesLibrary.Infrastructure.Services;

namespace MoviesLibrary.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(ctx =>
        {
            ctx.UseSqlServer(configuration.GetConnectionString("DefaultCS"));
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<IMovieService, MovieService>();

        return services;
    }
}