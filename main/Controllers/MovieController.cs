using FinalWebApiProject.Interfaces;
using Main.Data;
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

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            var movie = _context.GetMovieById(id);
            if(movie == null)
                return NotFound(id);

            return Ok(_context.GetMovieById(id));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.GetAllMovies());
        }
    }
}