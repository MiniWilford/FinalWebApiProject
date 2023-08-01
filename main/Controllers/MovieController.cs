using Main.Data;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;

        private readonly MovieContext _context;

        public MovieController(ILogger<MovieController> logger, MovieContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Movie.ToList());
        }
    }
}