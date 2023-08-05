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

        //Get
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

        //Put
        [HttpPut("id")]
        public async Task<IActionResult> PutFood(int id, Food selectedFood)
        {
            if (id != selectedFood.id)
            {
                return BadRequest();
            }

            _context.Entry(selectedFood).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodExists(id))
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
        public async Task<ActionResult<Book>> PostFood(Food selectedFood)
        {
          if (_context.Food == null)
          {
              return Problem("Entity set 'DatabaseContext.Food'  is null.");
          }
            _context.Food.Add(selectedFood);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFood", new { id = selectedFood.id }, selectedFood);
        }

        //Delete
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteFood(int id)
        {
            if (_context.Food == null)
            {
                return NotFound();
            }
            var selectedFood = await _context.Food.FindAsync(id);
            if (selectedFood == null)
            {
                return NotFound();
            }

            _context.Food.Remove(selectedFood);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FoodExists(int id)
        {
            return (_context.Food?.Any(e => e.id == id)).GetValueOrDefault();
        }

    }
}