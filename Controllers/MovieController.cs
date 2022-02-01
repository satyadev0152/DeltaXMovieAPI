using MovieAPI.Models;
using MovieAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    public MovieController()
    {
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<Movie>> GetAll() => MovieServices.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Movie> Get(int id)
    {
        var movie = MovieServices.Get(id);
        
        if(movie == null)
            return NotFound();

        return movie;
    }

    // POST action
    [HttpPost]
    public IActionResult Create(Movie movie)
    {            
    // This code will save the movie and return a result
    MovieServices.Add(movie);
    return CreatedAtAction(nameof(Create), new { id = movie.Id }, movie);
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Movie movie)
    {
    // This code will update the movie and return a result
    if (id != movie.Id)
        return BadRequest();

    var existingMovie = MovieServices.Get(id);
    if(existingMovie is null)
        return NotFound();

    MovieServices.Update(movie);           

    return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
    // This code will delete the movie and return a result
    var movie = MovieServices.Get(id);

    if (movie is null)
        return NotFound();

    MovieServices.Delete(id);

    return NoContent();
    }
}