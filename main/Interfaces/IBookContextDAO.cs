namespace FinalWebApiProject.Interfaces
{
    public interface IBookContextDAO {
        List<Books> GetAllBooks();
        Books GetBookById(int id);
    }
}