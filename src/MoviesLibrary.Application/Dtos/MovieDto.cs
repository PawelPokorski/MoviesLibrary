namespace MoviesLibrary.Application.Dtos;

public class MovieDto
{
    public string Title { get; set; } = null!;
    public int? ReleaseYear { get; set; }
    public decimal? Rating { get; set; }
    public string? Description { get; set; }
    public string? Genre { get; set; }
}