using System.Linq;
using FinalWebApiProject.Interfaces;
using Main.Migrations;
using Main.Model;

namespace Main.Data
{
    public class MovieContextDAO : IMovieContextDAO {
        private DataContext _context;

        public MovieContextDAO(DataContext context) {
            _context = context;
        }

        public List<Movies> GetAllMovies() {
            return _context.Movies.ToList();
        }

        public Movies GetMovieById(int id)
        {
            return (Movies)_context.Movies.Where(x => x.Id.Equals(id)); // TODO: .FirstOrDefault()
        }
    }
}