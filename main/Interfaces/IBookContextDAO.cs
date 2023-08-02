namespace FinalWebApiProject.Interfaces
{
    public interface IBookContextDAO {
        List<Books> GetAllBooks();
        Books GetBookByISBN(long ISBN);
    }
}