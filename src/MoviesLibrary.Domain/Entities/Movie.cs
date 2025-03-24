namespace MoviesLibrary.Domain.Entities;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int? ReleaseYear { get; set; }
    public decimal? Rating { get; set; }
    public string? Description { get; set; } = string.Empty;
    public string? Genre { get; set; }
}