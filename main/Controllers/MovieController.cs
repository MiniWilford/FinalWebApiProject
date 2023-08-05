using FinalWebApiProject.Interfaces;
using Main.Migrations;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;

        private readonly IMovieContextDAO _context;

        public MovieController(ILogger<MovieController> logger, IMovieContextDAO context)
        {
            _logger = logger;
            _context = context;
        }

        //Get
        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            var movie = _context.GetMovieById(id);
            if(movie == null)
                return NotFound(id);

            return Ok(movie);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.GetAllMovies());
        }

        //Put
        [HttpPut("id")]
        public async Task<IActionResult> PutMovie(int id, Movie selectedMovie)
        {
            if (id != selectedMovie.id)
            {
                return BadRequest();
            }

            _context.Entry(selectedMovie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //Post
        [HttpPost]
        public async Task<ActionResult<Book>> PostMovie(Book selectedMovie)
        {
          if (_context.Movie == null)
          {
              return Problem("Entity set 'DatabaseContext.Movie'  is null.");
          }
            _context.Movie.Add(selectedMovie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = selectedMovie.id }, selectedMovie);
        }

        //Delete
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (_context.Movie == null)
            {
                return NotFound();
            }
            var selectedMovie = await _context.Movie.FindAsync(id);
            if (selectedMovie == null)
            {
                return NotFound();
            }

            _context.Movie.Remove(selectedMovie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return (_context.Movie?.Any(e => e.id == id)).GetValueOrDefault();
        }


    }
}