using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesFullstackTerca.API.Request.Movies;
using MoviesFullstackTerca.API.Services;

namespace MoviesFullstackTerca.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class MovieController : ControllerBase
{
    private readonly MovieService _service = new();

    [HttpPost]
    public IActionResult Create(MovieCreateRequest request)
    {
        var movieService = new MovieService();
        var isCreated = movieService.Create(request);
        if (!isCreated)
            return BadRequest("Error to create movie!");
        return Ok("Movie created with success!");
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var movieService = new Services.MovieService();
        var movie = movieService.GetById(id);

        if (movie is null)
            return NotFound("Movie not found!");

        return Ok(movie);
    }
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var movieService = new Services.MovieService();

        var isDeleted = movieService.Delete(id);

        if (!isDeleted)
            return BadRequest("Error to delete movie!");

        return Ok("Movie deleted with success!");
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, MovieUpdateRequest request)
    {
        var movieService = new Services.MovieService();
        var isUpdated = movieService.Update(id, request);

        if (!isUpdated)
            return BadRequest("Error to update movie!");

        return Ok("Movie updated with success!");
    }

    [HttpGet("get-all")]
    public IActionResult GetAll()
    {
        var movieService = new Services.MovieService();
        var movies = movieService.GetAll();
        return Ok(movies);
    }
}
