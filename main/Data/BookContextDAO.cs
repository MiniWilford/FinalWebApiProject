using System.Linq;
using FinalWebApiProject.Interfaces;
using Main.Data;

namespace Main.Data
{
    public class BookContextDAO : IBookContextDAO {
        private BookContext _context;

        public BookContextDAO(BookContext context) {
            _context = context;
        }

        public List<Books> GetAllBooks() {
            return _context.Books.ToList();
        }

        public Books GetBookByISBN(long ISBN)
        {
            return (Books)_context.Books.Where(x => x.ISBN.Equals(ISBN)); // TODO: .FirstOrDefault()
        }
    }
}