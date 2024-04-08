using AbastWebApi.Models;

using InprocessWebApi.Repositories;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InprocessWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        // GET: api/<MovieController>
        [HttpGet]
        public async Task<ActionResult> GetMovies()
        {
            var movies=await _movieRepository.GetMovieList();

            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _movieRepository.GetMovieById(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            var movieInserted = await _movieRepository.AddMovie(movie);

            return Ok(movieInserted);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _movieRepository.DeleteMovie(id);
            if (movie == 0)
            {
                return NotFound();
            }
            //204 status code
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> PutMovie(Movie movie)
        {
           await _movieRepository.UpdateMovie(movie);
           //204 status code
            return NoContent();
        }

    }
}
