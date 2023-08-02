namespace FinalWebApiProject.Interfaces
{
    public interface IMovieContextDAO {
        List<Movies> GetAllMovies();
        Movies GetMovieById(int id);
    }
}