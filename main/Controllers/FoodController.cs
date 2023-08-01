using Main.Data;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class FoodController : ControllerBase
    {
        private readonly ILogger<FoodController> _logger;

        private readonly FoodContext _context;

        public FoodController(ILogger<FoodController> logger, FoodContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.FoodId.ToList());
        }
    }
}