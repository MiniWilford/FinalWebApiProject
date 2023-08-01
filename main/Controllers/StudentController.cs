using Main.Data;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;

        private readonly StudentContext _context;

        public StudentController(ILogger<StudentController> logger, StudentContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.StudentId.ToList());
        }
    }
}