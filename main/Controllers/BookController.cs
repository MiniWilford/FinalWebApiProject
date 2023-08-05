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

        //Get
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

        //Put
        [HttpPut("ISBN")]
        public async Task<IActionResult> PutBook(int ISBN, Book selectedBook)
        {
            if (ISBN != selectedBook.ISBN)
            {
                return BadRequest();
            }

            _context.Entry(selectedBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(ISBN))
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
        public async Task<ActionResult<Book>> PostBook(Book selectedBook)
        {
          if (_context.Book == null)
          {
              return Problem("Entity set 'DatabaseContext.Book'  is null.");
          }
            _context.Book.Add(selectedBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { ISBN = selectedBook.ISBN }, selectedBook);
        }

        //Delete
        [HttpDelete("ISBN")]
        public async Task<IActionResult> DeleteBook(int ISBN)
        {
            if (_context.Book == null)
            {
                return NotFound();
            }
            var selectedBook = await _context.Book.FindAsync(ISBN);
            if (selectedBook == null)
            {
                return NotFound();
            }

            _context.Book.Remove(selectedBook);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(int ISBN)
        {
            return (_context.Book?.Any(e => e.ISBN == ISBN)).GetValueOrDefault();
        }

    }
}