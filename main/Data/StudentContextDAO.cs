using System.Linq;
using FinalWebApiProject.Interfaces;

namespace Main.Data
{
    public class StudentContextDAO : IStudentContextDAO {
        private StudentContext _context;

        public StudentContextDAO(StudentContext context) {
            _context = context;
        }

        public List<Students> GetAllStudents() {
            return _context.Student.ToList();
        }

        public Students GetStudentById(int id)
        {
            return (Students)_context.Student.Where(x => x.StudentId.Equals(id)); // TODO .FirstOrDefault()
        }
    }
}