using Main.Model;

namespace FinalWebApiProject.Interfaces
{
    public interface IStudentContextDAO {
        List<Students> GetAllStudents();
        Students GetStudentById(int id);
    }
}