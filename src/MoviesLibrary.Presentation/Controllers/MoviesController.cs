using MoviesLibrary.Application.Services;
using Microsoft.AspNetCore.Mvc;
using MoviesLibrary.Application.Dtos;

namespace MoviesLibrary.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController(IMovieService movieService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetMovies([FromQuery] int? startYear, [FromQuery] int? endYear, [FromQuery] string[]? genres, [FromQuery] string? title, [FromQuery] int page = 1)
    {
        var result = await movieService.GetMovies(startYear, endYear, genres, title, page);

        // should return empty list if result == null, not a NotFound code

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMovieById([FromRoute] int id)
    {
        var result = await movieService.GetMovieById(id);
        
        if(result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddMovie([FromBody] MovieDto movieDto)
    {
        var result = await movieService.AddMovie(movieDto);

        if(!result.IsSuccess)
            return BadRequest(result.Errors);

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMovie([FromRoute] int id, [FromBody] MovieDto movieDto)
    {
        var result = await movieService.UpdateMovie(id, movieDto);

        if (!result.IsSuccess)
            return BadRequest(result.Errors);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovie([FromRoute] int id)
    {
        var result = await movieService.DeleteMovie(id);

        if (!result.IsSuccess)
            return BadRequest(result.Errors);

        return NoContent();
    }
}