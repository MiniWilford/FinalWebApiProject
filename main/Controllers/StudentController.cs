using FinalWebApiProject.Interfaces;
using Main.Data;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;

        private readonly IStudentContextDAO _context;

        public StudentController(ILogger<StudentController> logger, IStudentContextDAO context)
        {
            _logger = logger;
            _context = context;
        }

        //Get
        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            var student = _context.GetStudentById(id);
            if(student == null)
                return NotFound(id);

            return Ok(student);
        }

        
        [HttpGet]
        public IActionResult Get() {
            return Ok(_context.GetAllStudents());
        }

        //Put
        [HttpPut("id")]
        public async Task<IActionResult> PutStudent(int id, Student selectedStudent)
        {
            if (id != selectedStudent.id)
            {
                return BadRequest();
            }

            _context.Entry(selectedStudent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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
        public async Task<ActionResult<Book>> PostStudent(Book selectedStudent)
        {
          if (_context.Student == null)
          {
              return Problem("Entity set 'DatabaseContext.Student'  is null.");
          }
            _context.Student.Add(selectedStudent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = selectedStudent.id }, selectedStudent);
        }

        //Delete
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            if (_context.Student == null)
            {
                return NotFound();
            }
            var selectedStudent = await _context.Student.FindAsync(id);
            if (selectedStudent == null)
            {
                return NotFound();
            }

            _context.Student.Remove(selectedStudent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return (_context.Student?.Any(e => e.id == id)).GetValueOrDefault();
        }

    }
}