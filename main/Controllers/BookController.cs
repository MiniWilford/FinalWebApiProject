using Main.Data;
using Microsoft.AspNetCore.Mvc;
using FinalWebApiProject.Interfaces;

namespace Main.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;

        private readonly IBookContextDAO _context;

        public BookController(ILogger<BookController> logger, IBookContextDAO context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            var book = _context.GetBookById(id);
            if(book == null)
                return NotFound(id);

            return Ok(_context.GetBookById(id));
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.GetAllBooks());
        }
    }
}