using FinalWebApiProject.Interfaces;
using Main.Data;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class FoodController : ControllerBase
    {
        private readonly ILogger<FoodController> _logger;

        private readonly IFoodContextDAO _context;

        public FoodController(ILogger<FoodController> logger, IFoodContextDAO context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            var food = _context.GetFoodById(id);
            if(food == null)
                return NotFound(id);

            return Ok(food);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.GetAllFood());
        }
    }
}