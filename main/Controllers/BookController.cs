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

        [HttpGet("ISBN")]
        public IActionResult Get(long ISBN)
        {
            var book = _context.GetBookByISBN(ISBN);
            if(book == null)
                return NotFound(ISBN);

            return Ok(book);
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.GetAllBooks());
        }
    }
}