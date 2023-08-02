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
    }
}